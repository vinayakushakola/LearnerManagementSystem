//
// Author: Vinayak Ushakola
// Date: 25/05/2020
//

using LMSCommonLayer.RequestModels;
using LMSCommonLayer.ResponseModels;
using System.Collections.Generic;

namespace LMSBusinessLayer.Interface
{
    public interface ITechBusiness
    {
        List<TechStackResponse> ListOfTechStacks();

        TechStackResponse AddTechStack(TechStackRequest techStack);

        List<TechTypeResponse> ListOfTechTypes();

        TechTypeResponse AddTechType(TechTypeRequest techType);
    }
}
