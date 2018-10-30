using System;
using System.Collections.Generic;
using System.Text;

namespace FaceService
{
    public interface IFace
    {
        System.Threading.Tasks.Task<bool> CompareFacesAsync();
        void AddANewFace(string imageId);
    }
}
