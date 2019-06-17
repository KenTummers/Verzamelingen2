using KenTummersVerzamelingen2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KenTummersVerzamelingen2.ViewModels
{
    public class ViewModel
    {
        public IEnumerable<ParentFish> parentFish { get; set; }
        public IEnumerable<ChildFish> childFish { get; set; }

        public IEnumerable<ParentPokemon> parentPokemon { get; set; }
        public IEnumerable<ChildPokemon> childPokemons { get; set; }

        public IEnumerable<ParentYuGiOh> parentYuGiOh { get; set; }
        public IEnumerable<ChildYuGiOh> childYuGiOh { get; set; }
    }
}