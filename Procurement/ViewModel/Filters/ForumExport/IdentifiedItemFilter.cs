﻿using POEApi.Model;

namespace Procurement.ViewModel.Filters.ForumExport
{
    public class IdentifiedItemFilter : IFilter
    {
        public bool CanFormCategory
        {
            get
            {
                return false;
            }
        }

        public string Keyword
        {
            get
            {
                return "Identified Items";
            }
        }

        public string Help
        {
            get
            {
                return "Identified Items";
            }
        }

        public FilterGroup Group
        {
            get
            {
                return FilterGroup.Default;
            }
        }

        public bool Applicable(Item item)
        {
            if (!item.Identified)
            {
                return false;
            }
            else if (item is Map)
            {
                return true;
            }
            else if (!(item.MaxStackSize > 0))
            {
                Gear gear = item as Gear;
                if (gear != null)
                {
                    return !gear.TypeLine.StartsWith("Sacrifice at ")
                    && !gear.TypeLine.StartsWith("Mortal ")
                    && !gear.TypeLine.StartsWith("Fragment of the ")
                    && !gear.TypeLine.EndsWith(" Key")
                    && !gear.TypeLine.EndsWith(" Breachstone");
                }
            }
            
            return false;
        }
    }
}
