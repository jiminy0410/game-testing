using NUnit.Framework;
using UnityEngine;


namespace Tests
{
    public class editMode
    {
        [Test]
        public void MoveLeft()
        {
            var gameObject = new GameObject();
            var minion = gameObject.AddComponent<playerMove>();

            minion.PresentLane--;

            Assert.AreEqual(1, minion.PresentLane);
        }

        [Test]
        public void MoveRight()
        {
            var gameObject = new GameObject();
            var minion = gameObject.AddComponent<playerMove>();

            minion.PresentLane++;

            Assert.AreEqual(3, minion.PresentLane);
        }

        [Test]
        public void MoveJump()
        {
            var gameObject = new GameObject();
            var minion = gameObject.AddComponent<playerMove>();

            minion.jump = true;

            Assert.AreEqual(false, minion.grounded);
        }

        [Test]
        public void Dead()
        {
            var gameObject = new GameObject();
            var minion = gameObject.AddComponent<playerMove>();

            minion.dead();

            Assert.AreEqual(3, minion.live);
            Assert.AreEqual(new Vector3(0, 0, 0), minion.transform.position);
            Assert.AreEqual(2, minion.PresentLane);
            Assert.AreEqual(0, minion.score);
            Assert.AreEqual(0, minion.coins);
            Assert.AreEqual(0, minion.dist);
            Assert.AreEqual(180, minion.deadTimer);
            Assert.AreEqual(false, minion.forward);
        }
    }
}
