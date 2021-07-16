using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplicationGlobalSystemTeste.Data;
using WebApplicationGlobalSystemTeste.Models;

namespace WebApplicationGlobalSystemTeste.Services
{
    public class FighterService
    {
        #region Properties
        
        public FighterData Data { get; set; }
        public Task<List<FighterModel>> Task { get; set; }
        public List<FighterModel> ListSelect { get; set; }
        public List<FighterModel> ListRepository { get; set; }
        public List<FighterModel> ListFighters { get; set; }
        public List<FighterModel> ListSelectOrderBy { get; set; }
        public List<FighterModel> ListWednesdays { get; set; }
        public FighterService Service { get; set; }
        public FighterModel Model { get; set; }

        #endregion

        #region Constructor

        public FighterService()
        {
            
        }

        #endregion

        #region Methods

        public async Task<List<FighterModel>> FindAllAsync()
        {
            Data = new FighterData();
            Task = Data.GetFightersAsync();
            List<FighterModel> list = new List<FighterModel>();
            await Task.ContinueWith(task =>
            {
                ListFighters = task.Result;
                foreach (var fighter in ListFighters)
                {
                    Model = new FighterModel()
                    {
                        Id = fighter.Id,
                        Name = fighter.Name,
                        Age = fighter.Age,
                        MartialArts = fighter.MartialArts,
                        Fights = fighter.Fights,
                        Defeats = fighter.Defeats,
                        Victories = fighter.Victories
                    };
                    list.Add(Model);
                }
            },
            TaskContinuationOptions.OnlyOnRanToCompletion);
            return await Task;
        }


        public async Task<List<FighterModel>> FindSelectAsync(StringValues GetIds)
        {
            ListSelect = new List<FighterModel>();
            Service = new FighterService();
            ListRepository = await Service.FindAllAsync();
            var arr = GetIds.ToString().Split(",");
            foreach (var item in ListRepository)
            {
                for (int i = 0; i < arr.Length; i++)
                {
                    if (arr[i] == item.Id)
                    {
                        ListSelect.Add(item);
                    }
                }
            }
            ListSelectOrderBy = ListSelect.OrderBy(x => x.Age).ToList();
            return ListSelectOrderBy;
        }

        
        public List<FighterModel> WednesdaysAsync(List<FighterModel> ListFighterModel)
        {
            foreach (var item in ListFighterModel)
            {
                var percentage = (Convert.ToDouble(item.Victories) / Convert.ToDouble(item.Fights)) * 100;
                item.Percentage = Math.Truncate(percentage);
            }
            var ListPercentage = ListFighterModel.OrderBy(x => x.Percentage).ToList();
            ListPercentage.RemoveRange(7, 8);
            return ListPercentage;
        }

        public List<FighterModel> SemiFinalAsync(List<FighterModel> ListFighterModel)
        {
            var ListPercentage = ListFighterModel.OrderBy(x => x.Percentage).ToList();
            ListPercentage.RemoveRange(3, 4);
            return ListPercentage;
        }

        public List<FighterModel> FinalAsync(List<FighterModel> ListFighterModel)
        {
            var ListPercentage = ListFighterModel.OrderBy(x => x.Percentage).ToList();
            ListPercentage.RemoveRange(1, 2);
            return ListPercentage;
        }

        public List<FighterModel> ChampionAsync(List<FighterModel> ListFighterModel)
        {
            var ListPercentage = ListFighterModel.OrderBy(x => x.Percentage).ToList();
            ListPercentage.RemoveRange(0, 1);
            return ListPercentage;
        }

        #endregion
    }
}
