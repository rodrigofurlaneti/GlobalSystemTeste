using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplicationGlobalSystemTeste.Data;
using WebApplicationGlobalSystemTeste.Models;

namespace WebApplicationGlobalSystemTeste.Services
{
    public class FighterService
    {
        #region Properties
        
        public FighterData fighterData { get; set; }
        public Task<List<FighterModel>> task { get; set; }

        #endregion

        #region Constructor

        public FighterService()
        {
            
        }

        #endregion

        #region Methods

        public async Task<List<FighterModel>> FindAllAsync()
        {
            fighterData = new FighterData();
            task = fighterData.GetFightersAsync();
            List<FighterModel> list = new List<FighterModel>();
            await task.ContinueWith(task =>
            {
                var fighters = task.Result;
                foreach (var fighter in fighters)
                {
                    var newFighter = new FighterModel()
                    {
                        Id = fighter.Id,
                        Name = fighter.Name,
                        Age = fighter.Age,
                        MartialArts = fighter.MartialArts,
                        Fights = fighter.Fights,
                        Defeats = fighter.Defeats,
                        Victories = fighter.Victories
                    };
                    list.Add(newFighter);
                }
            },
            TaskContinuationOptions.OnlyOnRanToCompletion);
            return await task;
        }

        #endregion
    }
}
