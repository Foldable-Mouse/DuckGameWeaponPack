using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

[assembly: AssemblyTitle("Foldable's Weapon Pack")]
[assembly: AssemblyCompany("Foldable Mouse")]
[assembly: AssemblyDescription("GET THAT FOLDABLE (Discord: QBAyXzP)")]
[assembly: AssemblyVersion("1.0.0.2")]

namespace DuckGame.FoldableMod
{
    public class FoldableMod : Mod
    {
		public override Priority priority
		{
			get { return base.priority; }
		}
		protected override void OnPreInitialize()
		{
			base.OnPreInitialize();
		}
		protected override void OnPostInitialize()
		{
			base.OnPostInitialize();
		}
	}
}
