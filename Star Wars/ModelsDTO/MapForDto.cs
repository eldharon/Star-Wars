using Star_Wars.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Star_Wars.ModelsDTO
{
    public class MapForDto
    {
        public static List<CharacterEpisodeDTO> MapForDTO(List<Character> source)
        {
            var result = new List<CharacterEpisodeDTO>();
            foreach (var item in source)
            {
                var FriendsList = new List<string>();
                foreach (var friend in item.Friends)
                {
                    FriendsList.Add(friend.Name);
                }
                var EpisodesList = new List<string>();
                foreach (var episode in item.Episodes)
                {
                    EpisodesList.Add(episode.Name);
                }
                result.Add(new CharacterEpisodeDTO
                {
                    Episodes = EpisodesList,
                    Friends = FriendsList,
                    Name = item.Name,
                    Planet = item.Planet
                });              
            }
            return result;
        }
    }
}