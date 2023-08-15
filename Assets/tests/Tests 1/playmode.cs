using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class playmode
    {
        [UnityTest]
        public IEnumerator MoveLeft()
        {
            var gameObject = new GameObject();
            var minion = gameObject.AddComponent<playerMove>();

            minion.PresentLane--;

            yield return null;

            Assert.AreEqual(1, minion.PresentLane);
        }

        [UnityTest]
        public IEnumerator MoveRight()
        {
            var gameObject = new GameObject();
            var minion = gameObject.AddComponent<playerMove>();

            minion.PresentLane++;

            yield return null;

            Assert.AreEqual(3, minion.PresentLane);
        }

        [UnityTest]
        public IEnumerator MoveJump()
        {
            var gameObject = new GameObject();
            var minion = gameObject.AddComponent<playerMove>();

            minion.jump = true;

            yield return null;

            Assert.AreEqual(false, minion.grounded);
        }
    }
}
