using GoblinMan.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoblinMan
{
    public class GoblinRepository
    {
        string _dbPath;
        public string StatusMessage { get; set; }

        private SQLiteAsyncConnection conn;

        private async Task Init()
        {
            if (conn != null) return;

            conn = new SQLiteAsyncConnection(_dbPath);
            await conn.CreateTableAsync<Goblin>();
            InitInsert("Wolf", true, 1, 24, 15, 7, 7);
            InitInsert("Hunting Spider", true, 1, 16, 17, 7, 7);
            InitInsert("Unsafe Stairs", false, 0, 0, 0, 0, 16);
            InitInsert("Falling Debris", false, 1, 0, 0, 0, 20);
            InitInsert("Gurtlekep", true, 2, 30, 18, 17, 10);
        }

        public GoblinRepository(string dbPath)
        {
            _dbPath = dbPath;
        }

        private async void InitInsert(string name, bool isCreature, int lvl, int health, int armor, int perc, int st)
        {
            int result;
            try
            {
                result = await conn.InsertAsync(new Goblin { 
                    Name = name,
                    IsCreature = isCreature,
                    Level = lvl,
                    HealthMax = health,
                    Armor= armor,
                    Perception= perc,
                    Stealth= st
                });
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to add {0}. Error: {1}", name, ex.Message);
            }
        }

        public async Task<List<Goblin>> GetGoblins()
        {
            try
            {
                await Init();
                return await conn.Table<Goblin>().ToListAsync();
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to retrieve data. {0}", ex.Message);
            }

            return new List<Goblin>();
        }

        public async Task<Goblin> GetGoblinById(int id)
        {
            try
            {
                await Init();
                return await conn.Table<Goblin>()
                    .Where(i => i.Id == id)
                    .FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to retrieve data. {0}", ex.Message);
            }
            return null;
        }

    }

}
