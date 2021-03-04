using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleUI.MultitonDesign
{
    public class Camera
    {
        static Dictionary<string, Camera> _cameras = new Dictionary<string, Camera>();
        static object _lock = new object();
        private string brand;
        public Guid Id { get; private set; }

        public Camera()
        {
            Id = Guid.NewGuid();
        }


        public static Camera GetCamera(string brand)
        {
            lock (_lock)
            {
                if (!_cameras.ContainsKey(brand))
                {
                    _cameras.Add(brand,new Camera());
                }
            }
            return _cameras[brand];
        }
    }
}
