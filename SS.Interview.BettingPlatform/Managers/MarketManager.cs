using System;
using System.Linq;
using SS.Interview.BettingPlatform.MarketGeneration.Generators;
using SS.Interview.BettingPlatform.MarketGeneration.Models;
using SS.Interview.BettingPlatform.Requests;

namespace SS.Interview.BettingPlatform.Managers
{
    public class MarketManager
    {
        public Market[] Get(MarketRequest request)
        {
            Market[] markets;

            if (request.Sport == "FOOTBALL")
            {
                var footballGen = new FootballMarketGenerator();
                return footballGen.GetMarkets(request.Fixture);
            }
            else if (request.Sport == "tennis")
            {
                var tennisGen = new TennisMarketGenerator();
                var tennisMarkets = tennisGen.GetMarkets(request.Fixture);

                markets = new Market[tennisMarkets.Count];
                
                for (var i = 0; i < tennisMarkets.Count; i++)
                {
                    markets[i] = tennisMarkets.Skip(i).Take(1).First();
                }
            }
            else
            {
                throw new Exception();
            }

            return markets;
        }
    }
}