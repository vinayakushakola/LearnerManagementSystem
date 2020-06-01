//
// Author: Vinayak Ushakola
// Date: 25/05/2020
//

using LMSCommonLayer.RequestModels;
using LMSCommonLayer.ResponseModels;

namespace LMSBusinessLayer.Interface
{
    public interface ITechBusiness
    {
        TechStackResponse AddTechStack(TechStackRequest techStack);

        TechTypeResponse AddTechType(TechTypeRequest techType);
    }
}
