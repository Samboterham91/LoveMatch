using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LoveMatch.Models;
using SQLite;

namespace LoveMatch.Data;

public class Database
{
    private SQLiteAsyncConnection _database;
    public int? CurrentMemberId { get; private set; }

    public async Task Init()
    {
        if (_database != null) return;

        string dbPath = Path.Combine(FileSystem.AppDataDirectory, "lovematch.db3");
        _database = new SQLiteAsyncConnection(dbPath);

        await _database.CreateTableAsync<Member>();
    }

    public async Task<bool> Register(string username, string password)
    {
        await Init();

        var existing = await _database.Table<Member>()
            .Where(m => m.Username == username)
            .FirstOrDefaultAsync();

        if (existing != null) return false;

        var member = new Member();
        member.Username = username;
        member.Password = password;

        await _database.InsertAsync(member);
        return true;
    }

    public async Task<bool> Login(string username, string password)
    {
        await Init();

        var member = await _database.Table<Member>()
            .Where(m => m.Username == username && m.Password == password)
            .FirstOrDefaultAsync();

        CurrentMemberId = member?.Id;

        return member != null;
    }

    public async Task<bool> UpdateCurrentMemberProfile(string name, int age, string bio)
    {
        await Init();

        if (CurrentMemberId is null)
        {
            return false;
        }

        var member = await _database.Table<Member>()
            .Where(m => m.Id == CurrentMemberId.Value)
            .FirstOrDefaultAsync();

        if (member is null)
        {
            return false;
        }

        member.Name = name;
        member.Age = age;
        member.Bio = bio;

        var rows = await _database.UpdateAsync(member);
        return rows > 0;
    }

    public void Logout()
    {
        CurrentMemberId = null;
    }
}
