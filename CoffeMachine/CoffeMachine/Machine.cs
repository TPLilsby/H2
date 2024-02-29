using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeMachineProject
{
    public abstract class Machine
    {
        protected ILiquid Liquid;
        protected IIngredient Ingredient;
        protected bool HasFilter;
        protected int liquidPerCup;
        protected int CupsPerBrew;

        public virtual void AddLiquid(int milliliters)
        {
            Liquid.AddLiquid(milliliters);
        }

        public virtual void RemoveLiquid(int milliliters)
        {
            Liquid.RemoveLiquid(milliliters);
        }

        public virtual void AddIngredient(int grams)
        {
            Ingredient.AddIngredient(grams);
        }

        public virtual void RemoveIngredient(int grams)
        {
            Ingredient.RemoveIngredient(grams);
        }

        public abstract void Brew();

        public Machine(ILiquid liquid, IIngredient ingredient, int liquidPerCup, int cupsPerBrew)
        {
            this.Liquid = liquid;
            this.Ingredient = ingredient;
            this.HasFilter = true;
            this.liquidPerCup = liquidPerCup;
            CupsPerBrew = cupsPerBrew;
        }
    }
}
