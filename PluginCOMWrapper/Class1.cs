using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RGiesecke.DllExport;
using System.Runtime.InteropServices;
using System.Reflection;
using System.IO;
using PDFXEdit;

namespace PluginCOMWrp
{
    public class PluginWrp
    {
        static Assembly LoadFromSameFolder(object sender, ResolveEventArgs args)
        {
            string folderPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string assemblyPath = Path.Combine(folderPath, new AssemblyName(args.Name).Name + ".dll");
            if (File.Exists(assemblyPath) == false) return null;
            Assembly assembly = Assembly.LoadFrom(assemblyPath);
            return assembly;
        }

        static int _Create(uint nAPIVersion, System.IntPtr pReserved, ref IPXV_Plugin ppPlugin)
        {
            return PluginSample.MyTestPlugin.Create(nAPIVersion, pReserved, ref ppPlugin);

        }

        [DllExport("PXCE_GetPlugin", CallingConvention = CallingConvention.StdCall)]
        public static int Create(uint nAPIVersion, System.IntPtr pReserved, ref IPXV_Plugin ppPlugin)
        {
            //resolve some mistakes with path to dll(s)
            AppDomain currentDomain = AppDomain.CurrentDomain;
            currentDomain.AssemblyResolve += new ResolveEventHandler(LoadFromSameFolder);

            string folderPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string assemblyPath = Path.Combine(folderPath, "PluginSample.dll");
            Assembly.LoadFrom(assemblyPath);

            return _Create(nAPIVersion, pReserved, ref ppPlugin);
            //int res = -2147467259;// E_FAIL;


            //create plugins
            // IPXV_Plugin pp = ppPlugin;
        }

    }
}
