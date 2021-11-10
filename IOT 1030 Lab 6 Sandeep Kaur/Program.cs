using System;

using Psim.Particles;
using Psim.ModelComponents;
using Psim.Materials;

namespace Psim
{
	class Program
	{
		static void Main(string[] args)
		{
			DispersionData dData;
			dData.LaData = new double[] { -2.22e-7, 9260.0, 0.0 };
			dData.TaData = new double[] { -2.28e-7, 5240.0, 0.0 };
			dData.WMaxLa = 7.63916048e13;
			dData.WMaxTa = 3.0100793072e13;

			RelaxationData rData;
			rData.Bl = 1.3e-24;
			rData.Btn = 9e-13;
			rData.Btu = 1.9e-18;
			rData.BI = 1.2e-45;
			rData.W = 2.42e13;

			Material silicon = new Material(dData, in rData);
			Model model = new Model(silicon, 3100, 90, 10);
			int numCells = 10;
			for (int i=0; i<numCells; ++i)
            {
				model.AddSensor(i, 310);
				model.AddCell(i, i, 10);
            }
			model.SetSurface(300);
			model.SetemitPhonons(300, 1, 5e, 9);
			Console.WriteLine(model);

			// Test the AddSensor, AddCell and SetSurfaces implementations. 
		}
	}
}
