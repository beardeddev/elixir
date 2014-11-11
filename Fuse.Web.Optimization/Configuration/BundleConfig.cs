using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Optimization;

namespace Fuse.Web.Optimization.Configuration
{
    public class BundleConfig
    {
        private static readonly BundleSection section = (BundleSection)ConfigurationManager.GetSection("system.web.optimization.bundles");

        public static void RegisterBundles(BundleCollection bundles)
        {
            BundleConfig.RegisterBundles(bundles, section.Scripts, (x) => { return new ScriptBundle(x); });
            BundleConfig.RegisterBundles(bundles, section.Styles, (x) => { return new StyleBundle(x); });
        }

        private static void RegisterBundles(BundleCollection bundles, BundleElementCollection elements, Func<string, Bundle> bundle)
        {
            foreach (BundleElement element in elements)
            {
                List<string> files = new List<string>(element.Files.Count);

                foreach (FileElement file in element.Files)
                {
                    files.Add(file.VirtualPath);
                }

                bundles.Add(bundle(element.VirtualPath).Include(files.ToArray()));
            }
        }
    }
}
