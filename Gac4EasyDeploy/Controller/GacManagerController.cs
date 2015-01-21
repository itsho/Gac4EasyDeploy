using System;
using System.IO;
using System.Reflection;
using System.Windows.Input;
using Gac4EasyDeploy.Model;

namespace Gac4EasyDeploy.Controller
{
    internal class GacManagerController
    {
        private readonly GacManagerModel m_gacManagerModel;


        //HKEY_LOCAL_MACHINE\Software\Microsoft\Fusion  (DWORD) DisableCacheViewer = 1
        public ICommand OpenFusionLog;


        public GacManagerController(GacManagerModel p_gacManagerModel)
        {
            m_gacManagerModel = p_gacManagerModel;
        }

        public void AddFileToSymbolsStore(String p_strPDBFile)
        {
            //symstore add /f <path to PDB> /s C:\symbols /t "My Product"
        }


        public void DeployFile(string p_strAssemblyPath)
        {
            foreach (string strExtention in m_gacManagerModel.ExtraExtentions)
            {
                string strExtraExtentionFilename = string.Format("{0}.{1}", Path.GetFileNameWithoutExtension(p_strAssemblyPath), strExtention);

                string strExtraExtentionFilePath = Path.Combine(Path.GetDirectoryName(p_strAssemblyPath), strExtraExtentionFilename);

                //if source PDB is found:
                if (File.Exists(strExtraExtentionFilePath))
                {
                    //get the strong name info from the assembly:
                    AssemblyName gacAssemblyName = Assembly.LoadFile(p_strAssemblyPath).GetName();

                    string gacPath = GetGacPhysicalLocation(gacAssemblyName);

                    //if GAC location found:
                    if (!string.IsNullOrEmpty(gacPath))
                    {

                        try
                        {
                            File.Copy(strExtraExtentionFilePath, Path.Combine(gacPath, strExtraExtentionFilename));

                        }
                        catch (Exception ex)
                        {
                        }
                    }
                }  
            }
         
        }

        private string GetGacPhysicalLocation(AssemblyName gacAssemblyName)
        {
            throw new NotImplementedException();
        }
    }
}