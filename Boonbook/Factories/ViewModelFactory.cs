using Boonbook.Models.Boons;
using Boonbook.Models.Boons.ViewModels;
using Boonbook.Models.Characters;
using Boonbook.Models.Characters.ViewModels;
using Boonbook.Models.Users;
using Boonbook.Models.Users.ViewModels;

namespace Boonbook.Factories
{
    public static class ViewModelFactory
    {

        // Players

        public static PlayerSummaryViewModel UserSummary(Player user)
        {
            return new PlayerSummaryViewModel
            {
                MesNumber = user.MesNumber,
                Name = user.FirstName + " " + user.LastName
            };
        }

        public static PlayerDetailViewModel PlayerDetail(Player player)
        {
            return new PlayerDetailViewModel();
        }



        // Characters 

        public static CharacterSummaryViewModel CharacterSummary(Character character)
        {
            return new CharacterSummaryViewModel
            {
                Id = character.Id,
                Name = character.Name
            };
        }

        public static CharacterDetailViewModel CharacterDetail(Character character)
        {
            return new CharacterDetailViewModel();
        }



        // Boons

        public static BoonSummaryViewModel BoonSummary(Boon boon)
        {
            return new BoonSummaryViewModel
            {
                Id = boon.Id,
                Level = boon.Level.Name,
                Debtor = CharacterSummary(boon.Debtor),
                Creditor = CharacterSummary(boon.Creditor)
            };
        }

        public static BoonDetailViewModel BoonDetail(Boon boon)
        {
            return new BoonDetailViewModel();
        }

    }
}