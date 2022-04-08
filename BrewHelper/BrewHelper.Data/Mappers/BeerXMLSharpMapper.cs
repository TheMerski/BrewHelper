using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BrewHelper.Data.Entities;

namespace BrewHelper.Data.Mappers;
public static class BeerXMLSharpMapper
{
    public static IEnumerable<Recipe> ToRecipeEnumerator(this RECIPES recipes)
    {
        return recipes.RECIPE.Select(r => r.ToRecipe()).AsEnumerable();
    }

    public static Recipe ToRecipe(this RECIPESRECIPE recipe)
    {
        return new Recipe
        {
            Name = recipe.NAME,
            Version = recipe.VERSION,
            BatchSize = decimal.ToDouble(recipe.BATCH_SIZE),
            BoilSize = decimal.ToDouble(recipe.BOIL_SIZE),
            BoilTime = decimal.ToDouble(recipe.BOIL_TIME),
            Brewer = recipe.BREWER,
            Type = Enum.Parse<RecipeType>(recipe.TYPE.Replace(' ', '_'), true),
            Notes = recipe.NOTES,
            Fermentables = recipe.FERMENTABLES.Select(f => f.ToFermetable()).ToList(),
            Hops = recipe.HOPS.Select(h => h.ToHop()).ToList(),
            Yeasts = recipe.YEASTS.Select(y => y.ToYeast()).ToList(),
            Mash = recipe.MASH.ToMash(),
            Style = recipe.STYLE.ToStyle(),
            Waters = recipe.WATERS.Select(w => w.ToWater()).ToList(),
            Miscs = recipe.MISCS.Select(m => m.ToMisc()).ToList(),
        };
    }

    public static Fermentable ToFermetable(this RECIPESRECIPEFERMENTABLE fermentable)
    {
        return new Fermentable
        {
            Name = fermentable.NAME,
            Version = fermentable.VERSION,
            Amount = decimal.ToDouble(fermentable.AMOUNT),
            Color = decimal.ToDouble(fermentable.COLOR),
            Type = Enum.Parse<FermentableType>(fermentable.TYPE.Replace(' ', '_'), true),
            Yield = decimal.ToDouble(fermentable.YIELD),
            Notes = fermentable.NOTES,
        };
    }

    public static Hop ToHop(this RECIPESRECIPEHOP hop)
    {
        return new Hop
        {
            Name = hop.NAME,
            Version = hop.VERSION,
            Alpha = decimal.ToDouble(hop.ALPHA),
            Time = decimal.ToDouble(hop.TIME),
            Amount = decimal.ToDouble(hop.AMOUNT),
            Use = Enum.Parse<HopUse>(hop.USE.Replace(' ', '_'), true),
            Notes = hop.NOTES,
        };
    }

    public static Yeast ToYeast(this RECIPESRECIPEYEAST yeast)
    {
        return new Yeast
        {
            Name = yeast.NAME,
            Version = yeast.VERSION,
            Amount = decimal.ToDouble(yeast.AMOUNT),
            Notes = yeast.NOTES,
            Form = Enum.Parse<YeastForm>(yeast.FORM.Replace(' ', '_'), true),
            Type = Enum.Parse<YeastType>(yeast.TYPE.Replace(' ', '_'), true),
        };
    }

    public static Mash ToMash(this RECIPESRECIPEMASH mash)
    {
        return new Mash
        {
            Name = mash.NAME,
            Version = mash.VERSION,
            GrainTemp = decimal.ToDouble(mash.GRAIN_TEMP),
            Notes = mash.NOTES,
            MashSteps = mash.MASH_STEPS.Select(ms => ms.ToMashStep()).ToList(),
        };
    }

    public static MashStep ToMashStep(this RECIPESRECIPEMASHMASH_STEP step)
    {
        return new MashStep
        {
            Name = step.NAME,
            Version = step.VERSION,
            StepTemp = decimal.ToDouble(step.STEP_TEMP),
            StepTime = step.STEP_TIME,
            InfuseAmount = step.INFUSE_AMOUNT != null ? decimal.ToDouble((decimal)step.INFUSE_AMOUNT) : null,
            Type = Enum.Parse<MashStepType>(step.TYPE.Replace(' ', '_'), true)
        };
    }

    public static Style ToStyle(this RECIPESRECIPESTYLE style)
    {
        return new Style
        {
            Name = style.NAME,
            Version = style.VERSION,
            Category = style.CATEGORY,
            CategoryNumber = style.CATEGORY_NUMBER,
            ColorMax = decimal.ToDouble(style.COLOR_MAX),
            ColorMin = decimal.ToDouble(style.COLOR_MIN),
            IBU_Max = decimal.ToDouble(style.IBU_MAX),
            IBU_Min = decimal.ToDouble(style.IBU_MIN),
            OG_Max = decimal.ToDouble(style.OG_MAX),
            OG_Min = decimal.ToDouble(style.OG_MIN),
            StyleGuide = style.STYLE_GUIDE,
            StyleLetter = style.STYLE_LETTER,
            Notes = style.NOTES,
            Type = Enum.Parse<StyleType>(style.TYPE.Replace(' ', '_'), true)
        };
    }

    public static Water ToWater(this RECIPESRECIPEWATER water)
    {
        return new Water
        {
            Name = water.NAME,
            Version = water.VERSION,
            Amount = decimal.ToDouble(water.AMOUNT),
            Calcium = decimal.ToDouble(water.CALCIUM),
            Bicarbonate = decimal.ToDouble(water.BICARBONATE),
            Chloride = decimal.ToDouble(water.CHLORIDE),
            Sulfate = decimal.ToDouble(water.SULFATE),
            Sodium = decimal.ToDouble(water.SODIUM),
            Magnesium = decimal.ToDouble(water.MAGNESIUM),
            Notes = water.NOTES,
        };
    }

    public static Misc ToMisc(this RECIPESRECIPEMISC misc)
    {
        return new Misc
        {
            Name = misc.NAME,
            Version = misc.VERSION,
            Amount = decimal.ToDouble(misc.AMOUNT),
            Type = Enum.Parse<MiscType>(misc.TYPE.Replace(' ', '_'), true),
            Use = Enum.Parse<MiscUse>(misc.USE.Replace(' ', '_'), true),
            Time = decimal.ToDouble(misc.TIME),
            Notes = misc.NOTES,
        };
    }
}
