using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PDFXEdit;
using System.IO;
using System.Reflection;

namespace PluginSample
{
    public class MyTestPlugin : IPXV_Plugin
    {
		IPXV_Inst m_Inst;

		static Assembly LoadFromSameFolder(object sender, ResolveEventArgs args)
		{
			string folderPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
			string assemblyPath = Path.Combine(folderPath, new AssemblyName(args.Name).Name + ".dll");
			if (File.Exists(assemblyPath) == false) return null;
			Assembly assembly = Assembly.LoadFrom(assemblyPath);
			return assembly;
		}

		public static int Create(uint nAPIVersion, System.IntPtr pReserved, ref IPXV_Plugin ppPlugin)
		{
			//resolve some mistakes with path to dll(s)
			AppDomain currentDomain = AppDomain.CurrentDomain;
			currentDomain.AssemblyResolve += new ResolveEventHandler(LoadFromSameFolder);

			//create plugins
			ppPlugin = new MyTestPlugin();

			return 0;
		}

		public MyTestPlugin()
		{
		}

		public void Setup(PXV_Inst pInstance)
		{
			m_Inst = pInstance;
		}

		public void RegisterExts()
		{
			//throw new NotImplementedException();
		}

		public void FinalizeRegistering()
		{
			//throw new NotImplementedException();
		}

		public void Init()
		{
			//throw new NotImplementedException();
		}

		public void Unload()
		{
			m_Inst = null;

			GC.Collect();
			GC.WaitForPendingFinalizers();
		}

		public void ShowPrefsDlg(uint hWndParent)
		{
			//throw new NotImplementedException();
		}

		public void ImportAdditionalData(IAFS_Name pPathToAppData, IAFS_Name pPathToUserData)
		{
			//throw new NotImplementedException();
		}

		public void ExportAdditionalData(IAFS_Name pPathToAppData, IAFS_Name pPathToUserData)
		{
			//throw new NotImplementedException();
		}

		public void ResetSettings(uint nFlags)
		{
			//throw new NotImplementedException();
		}

		public Guid _GUID
		{
			get
			{
				Guid thisGuid = new Guid(0x9c2d5ade, 0x9d7f, 0x49dd, 0x82, 0x1d, 0x91, 0xb2, 0xc5, 0xf6, 0xe1, 0xa4);
				return thisGuid;
			}
		}

		public string Name
		{
			get { return ("TestPlugin"); }
		}

		public string CopyrightInfo
		{
			get { return ("Copyright (c) 2017 My Company."); }
		}

		public uint version
		{
			get { return (uint)(((ushort)0) | (uint)(1 << 16)); }
		}

		public uint VendorID
		{
			get { return 0; }
		}

		public string Description
		{
			get { return ("Plugin Description."); }
		}

		public string LegalInfo
		{
			get { return ("Copyright (c) 2017 My Company.\nAll right reserved."); }
		}

		public string Publisher
		{
			get { return ("My Company"); }
		}

		public uint Features
		{
			get { return 0; }
		}
	}
	
}
