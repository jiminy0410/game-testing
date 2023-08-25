using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;

namespace Tests
{
    public class AStart
    {
        [UnityTest]
        public IEnumerator SampleScene()
        {
            SceneManager.LoadScene("SampleScene");

            yield return null;

            Assert.AreEqual("SampleScene", SceneManager.GetActiveScene().name);
        }
    }

    public class Playmode
    {
        [UnityTest]
        public IEnumerator MoveLeft()
        {
            var gameObject = GameObject.Find("player");
            var minion = gameObject.GetComponent<playerMove>();
            minion.dead();

            minion.PresentLane--;

            yield return null;

            Assert.AreEqual(1, minion.PresentLane);
        }

        [UnityTest]
        public IEnumerator MoveRight()
        {

            var gameObject = GameObject.Find("player");
            var minion = gameObject.GetComponent<playerMove>();
            minion.dead();

            minion.PresentLane++;

            yield return null;

            Assert.AreEqual(3, minion.PresentLane);
        }

        [UnityTest]
        public IEnumerator MoveJump()
        {

            var gameObject = GameObject.Find("player");
            var minion = gameObject.GetComponent<playerMove>();
            minion.dead();

            minion.jump = true;

            yield return new WaitForSeconds(0.1f);

            Assert.AreEqual(false, minion.grounded);
        }

        [UnityTest]
        public IEnumerator Dead()
        {

            var gameObject = GameObject.Find("player");
            var minion = gameObject.GetComponent<playerMove>();

            minion.dead();

            Assert.AreEqual(3, minion.live);
            Assert.AreEqual(new Vector3(0, 0, 0), minion.transform.position);
            Assert.AreEqual(2, minion.PresentLane);
            Assert.AreEqual(0, minion.score);
            Assert.AreEqual(0, minion.coins);
            Assert.AreEqual(0, minion.dist);
            Assert.AreEqual(10, minion.speed);
            Assert.AreEqual(null, minion.hitObject);
            Assert.AreEqual(null, minion.coin);
            Assert.AreEqual(180, minion.deadTimer);
            Assert.AreEqual(false, minion.forward);

            yield return null;
        }
    }
    public class CollCheck
    {
        [UnityTest]
        public IEnumerator Enemy()
        {
            var gameObject = GameObject.Find("player");
            var minion = gameObject.GetComponent<playerMove>();
            minion.dead();

            yield return new WaitForSeconds(1f);

            Debug.Log(minion.hitObject);
            Assert.AreEqual(true, minion.hitObject.CompareTag("meen"));
        }

        [UnityTest]
        public IEnumerator Coin()
        {
            var gameObject = GameObject.Find("player");
            var minion = gameObject.GetComponent<playerMove>();
            minion.dead();

            minion.PresentLane++;

            yield return new WaitForSeconds(1f);

            Debug.Log(minion.coin);
            Assert.AreEqual(true, minion.coin.CompareTag("coin"));
        }
    }
    public class FullRunner
    {
        [UnityTest]
        public IEnumerator RunMap()
        {
            yield return null;

            var gameObject = GameObject.Find("player");
            var minion = gameObject.GetComponent<playerMove>();
            minion.dead();
            minion.die = true;

            yield return new WaitForSeconds(0.7f);

            minion.PresentLane++;

            yield return new WaitForSeconds(0.5f);

            minion.PresentLane--;

            yield return new WaitForSeconds(0.8f);

            minion.jump = true;

            yield return new WaitForSeconds(1.2f);

            minion.jump = true;

            yield return new WaitForSeconds(2f);

            minion.PresentLane--;

            yield return new WaitForSeconds(0.7f);

            minion.jump = true;

            yield return new WaitForSeconds(1.6f);

            minion.PresentLane++;

            yield return new WaitForSeconds(0.1f);

            minion.PresentLane++;

            yield return new WaitForSeconds(0.7f);

            minion.PresentLane--;

            yield return new WaitForSeconds(0.1f);

            minion.PresentLane--;

            yield return new WaitForSeconds(2f);

            minion.jump = true;

            yield return new WaitUntil(() => minion.live == 0);

            Assert.IsTrue(minion.transform.position.z > 195);
        }
    }
}
