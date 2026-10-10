namespace Project.Tests {
    public class LightSwitchTests {
        [TestCase(2, false)]
        [TestCase(0, false)]
        [TestCase(1, true)]
        public void Toggle_SetsCorrectState(int switches, bool expectedState) {
            LightSwitch s = new(false);

            for (int i = 0; i < switches; i++) {
                s.Toggle();
            }

            Assert.That(s.IsOn, Is.EqualTo(expectedState));
        }

        [TestCase(10)]
        [TestCase(5)]
        [TestCase(12)]
        [TestCase(1)]
        [TestCase(0)]
        [TestCase(100)]
        public void Toogle_Switches_ReturnsCorrectCount(int switches) {
            LightSwitch s = new(false);

            for (int i = 0; i < switches; i++) {
                s.Toggle();
            }

            Assert.That(s.Switches, Is.EqualTo(switches));
        }
    }
}