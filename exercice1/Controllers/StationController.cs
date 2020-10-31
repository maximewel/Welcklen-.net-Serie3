using exercice1.Models;
using exercice1.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading;

namespace exercice1.Controllers
{
    class StationController
    {
        private StationParser sp;
        public StationController()
        {
            sp = new StationParser();
        }

        private static int CostForFamily(Station s)
        {
            if (s.AdultCost == null || s.ChildrenCost == null)
            {
                throw new InvalidOperationException("Can not calculate cost from null cost");
            }
            return (int)(2 * s.AdultCost + 2 * s.ChildrenCost);
        }

        public void Start()
        {
            //2.Affichage de la liste des différents cantons présents
            //get cantons
            var distinctCantons = sp.GetStations().Select(s => s.Canton).Distinct();
            //display
            StationView.StartSection("Different cantons");
            StationView.DisplayEnumerable(distinctCantons, true, " ");
            StationView.EndSection();

            //3.Affichage des informations de toutes les stations de ski 
            //a)   triées par Canton, et alphabétiquement(croissant)
            var orderedCantons = sp.GetStations().OrderBy(s => s.Name).OrderBy(s => s.Canton).Select(s => $"{s.Name}, canton {s.Canton}");
            StationView.StartSection("All stations, ordered by canton then name");
            StationView.DisplayEnumerable(orderedCantons, false, "station : ");
            StationView.EndSection();

            //b)   dont le prix pour une famille de 2 enfants et 2 adultes est inférieur à 150.- / jour
            //if cost are null, we do not take them ! We can not calculate the family price
            var ordrerdPrice = sp.GetStations().Where(s => s.AdultCost!=null && s.ChildrenCost != null).Where(s => CostForFamily(s) < 150).Select(s => $"{s.Name}, price for family : {CostForFamily(s)}");
            StationView.StartSection("Station with corst for family < 150");
            StationView.DisplayEnumerable(ordrerdPrice, false, "station : ");
            StationView.EndSection();

        }
    }
}
