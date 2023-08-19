using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;

namespace Tests
{
    public class Playmode
    {
        [UnityTest]
        public IEnumerator MoveLeft()
        {
            SceneManager.LoadScene("SampleScene");
            var gameObject = GameObject.Find("player");
            var minion = gameObject.GetComponent<playerMove>();

            minion.PresentLane--;

            yield return null;

            Assert.AreEqual(1, minion.PresentLane);
        }

        [UnityTest]
        public IEnumerator MoveRight()
        {
            SceneManager.LoadScene("SampleScene");
            var gameObject = GameObject.Find("player");
            var minion = gameObject.GetComponent<playerMove>();

            minion.PresentLane++;

            yield return null;

            Assert.AreEqual(3, minion.PresentLane);
        }

        [UnityTest]
        public IEnumerator MoveJump()
        {
            SceneManager.LoadScene("SampleScene");
            var gameObject = GameObject.Find("player");
            var minion = gameObject.GetComponent<playerMove>();

            minion.jump = true;

            yield return null;

            Assert.AreEqual(false, minion.grounded);
        }

        [UnityTest]
        public IEnumerator Dead()
        {
            SceneManager.LoadScene("SampleScene");
            var gameObject = GameObject.Find("player");
            var minion = gameObject.GetComponent<playerMove>();

            minion.dead();

            Assert.AreEqual(3,minion.live);
            Assert.AreEqual(new Vector3(0, 0, 0), minion.transform.position);
            Assert.AreEqual(2,minion.PresentLane);
            Assert.AreEqual(0,minion.score);
            Assert.AreEqual(0,minion.coins);
            Assert.AreEqual(0,minion.dist);
            Assert.AreEqual(180,minion.deadTimer);
            Assert.AreEqual(false,minion.forward);

            yield return null;
        }
    }
    public class CollCheck
    {
        [UnityTest]
        public IEnumerator MoveJump()
        {
            SceneManager.LoadScene("SampleScene");
            var gameObject = GameObject.Find("player");
            var minion = gameObject.GetComponent<playerMove>();

            minion.jump = true;

            yield return null;

            Assert.AreEqual(false, minion.grounded);
        }
    }
    public class FullRunner
    {
        [UnityTest]
        public IEnumerator RunMap()
        {
            SceneManager.LoadScene("SampleScene");

            yield return null;

            var gameObject = GameObject.Find("player");
            var minion = gameObject.GetComponent<playerMove>();
            var body = gameObject.GetComponent<Rigidbody>();

            Debug.Log(body);

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

            yield return new WaitForSeconds(2.3f);

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
