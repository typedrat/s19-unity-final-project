using System;
using UnityEngine;

namespace Hanover.Physics
{
    using Fn = Func<float, Vector2, Vector2>;
    using Fn2 = Func<float, Vector2, Vector2, Vector2>;

    public class FirstOrderRungeKutta4
    {
        private Fn F;
        private float Step;
        public float Time { get; private set; }
        public Vector2 Solution { get; private set; }

        public FirstOrderRungeKutta4(Fn F_, float Step_, Vector2 Initial)
        {
            F = F_;
            Step = Step_;
            Time = 0;
            Solution = Initial;
        }

        public Vector2 Update()
        {
            var k1 = Step * F(Time, Solution);
            var k2 = Step * F(Time + 0.5f * Step, Solution + 0.5f * k1);
            var k3 = Step * F(Time + 0.5f * Step, Solution + 0.5f * k2);
            var k4 = Step * F(Time + Step, Solution + k3);

            Time += Step;
            Solution += (k1 + 2*k2 + 2*k3 + k4) / 6;

            return Solution;
        }

    }

    public class SecondOrderRungeKutta4
    {
        private Fn2 F, G;
        private float Step;
        public float Time { get; private set; }
        public Vector2 SolutionF { get; private set; }
        public Vector2 SolutionG { get; private set; }

        public SecondOrderRungeKutta4(Fn2 F_, Fn2 G_, float Step_, Vector2 InitialF, Vector2 InitialG)
        {
            F = F_;
            G = G_;
            Step = Step_;
            Time = 0;
            SolutionF = InitialF;
            SolutionG = InitialG;
        }

        public void Update()
        {
            var k1 = Step * F(Time, SolutionF, SolutionG);
            var l1 = Step * G(Time, SolutionF, SolutionG);
            var k2 = Step * F(Time + 0.5f * Step, SolutionF + 0.5f * k1, SolutionG + 0.5f * l1);
            var l2 = Step * G(Time + 0.5f * Step, SolutionF + 0.5f * k1, SolutionG + 0.5f * l1);
            var k3 = Step * F(Time + 0.5f * Step, SolutionF + 0.5f * k2, SolutionG + 0.5f * l2);
            var l3 = Step * G(Time + 0.5f * Step, SolutionF + 0.5f * k2, SolutionG + 0.5f * l2);
            var k4 = Step * F(Time + Step, SolutionF + k3, SolutionF + l3);
            var l4 = Step * G(Time + Step, SolutionF + k3, SolutionF + l3);
            SolutionF += (k1 + 2 * k2 + 2 * k3 + k4) / 6;
            SolutionG += (l1 + 2 * l2 + 2 * l3 + l4) / 6;
            Time += Step;
        }
    }
}