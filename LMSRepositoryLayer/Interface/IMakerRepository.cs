//
// Author: Vinayak Ushakola
// Date: 25/05/2020
//

using LMSCommonLayer.RequestModels;
using LMSCommonLayer.ResponseModels;

namespace LMSRepositoryLayer.Interface
{
    public interface IMakerRepository
    {
        MakerProgramResponse AddMakerProgram(MakerProgramRequest makerProgram);
    }
}
