using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lab10Lib;

namespace Lab10Tests
{
    [TestClass]
    public class EmojiTest
    {
        [TestMethod]
        public void TestEmptyEmoji()
        {
            Emoji e = new Emoji();
            Emoji expE = new Emoji("Пустая эмоция", "Empty");
            Assert.AreEqual(e, expE);
        }
        [TestMethod]
        public void TestCopyEmoji()
        {
            Emoji e = new Emoji("abc", "123");
            Emoji expE = new Emoji(e);
            Assert.AreEqual(e, expE);
        }
        [TestMethod]
        public void TestIdEmoji()
        {
            Emoji e = new Emoji(1, "abc", "123");
            Emoji expE = new Emoji();
            expE.Id = 1;
            expE.Name = "abc";
            expE.Tag = "123";

            Assert.AreEqual(e, expE);
        }
        [TestMethod]
        public void TestNegativeIdEmoji()
        {
            Emoji e = new Emoji(-5, "abc", "123");
            Emoji expE = new Emoji();
            expE.Id = 0;
            expE.Name = "abc";
            expE.Tag = "123";

            Assert.AreEqual(e, expE);
        }
        [TestMethod]
        public void TestRandomInitEmoji()
        {
            Emoji e = new Emoji();
            e.RandomInit();
            Emoji expE = new Emoji(e);
            Assert.AreEqual(e, expE);
        }
        [TestMethod]
        public void TestEmojiEqual1()
        {
            Emoji e = new Emoji("abc", "123");
            int n = 100;
            Assert.AreNotEqual(e, n);
        }
        [TestMethod]
        public void TestEmojiEqual2()
        {
            Emoji e = new Emoji("abc", "123");
            Assert.AreNotEqual(e, null);
        }
        [TestMethod]
        public void TestEmojiEqual3()
        {
            Emoji e = new Emoji("abc", "123");
            Emoji expE = new Emoji("abc", "123");
            Assert.AreEqual(e, expE);
        }
        [TestMethod]
        public void TestEmojiCompareTo()
        {
            Emoji e = new Emoji("abc", "123");
            Emoji expE = new Emoji("abc", "345");
            int res = e.CompareTo(expE);
            bool ans = false;
            if (res == 0) {
                ans = true;
            }
            Assert.IsTrue(ans);
        }
        [TestMethod]
        public void TestEmojiClone()
        {
            Emoji e = new Emoji("abc", "123");
            Emoji expE = (Emoji)e.Clone();
            Assert.AreEqual(e, expE);
        }
    }

    [TestClass]
    public class FaceEmojiTest
    {
        [TestMethod]
        public void TestFaceEmojiEmpty()
        {
            FaceEmoji e = new FaceEmoji();
            FaceEmoji expE = new FaceEmoji("Пустая эмоция", "Empty", "-_-", 0);
            Assert.AreEqual(e, expE);
        }
        [TestMethod]
        public void TestFaceEmojiCopy()
        {
            FaceEmoji e = new FaceEmoji("abc", "123", "qwerty", 5);
            FaceEmoji expE = new FaceEmoji(e);
            Assert.AreEqual(e, expE);
        }
        [TestMethod]
        public void TestFaceEmojiId()
        {
            FaceEmoji e = new FaceEmoji(1, "abc", "123", "qwerty", 5);
            FaceEmoji expE = new FaceEmoji();
            expE.Id = 1;
            expE.Name = "abc";
            expE.Tag = "123";
            expE.Desc = "qwerty";
            expE.Str = 5;

            Assert.AreEqual(e, expE);
        }
        [TestMethod]
        public void TestFaceEmojiNegativeId()
        {
            FaceEmoji e = new FaceEmoji(-5, "abc", "123", "qwerty", 5);
            FaceEmoji expE = new FaceEmoji();
            expE.Id = 0;
            expE.Name = "abc";
            expE.Tag = "123";
            expE.Desc = "qwerty";
            expE.Str = 5;

            Assert.AreEqual(e, expE);
        }
        [TestMethod]
        public void TestFaceEmojiRandomInit()
        {
            FaceEmoji e = new FaceEmoji();
            e.RandomInit();
            FaceEmoji expE = new FaceEmoji(e);
            Assert.AreEqual(e, expE);
        }
        [TestMethod]
        public void TestFaceEmojiEqual1()
        {
            FaceEmoji e = new FaceEmoji("abc", "123", "qwerty", 5);
            int n = 100;
            Assert.AreNotEqual(e, n);
        }
        [TestMethod]
        public void TestFaceEmojiEqual2()
        {
            FaceEmoji e = new FaceEmoji("abc", "123", "qwerty", 5);
            Assert.AreNotEqual(e, null);
        }
        [TestMethod]
        public void TestFaceEmojiEqual3()
        {
            FaceEmoji e = new FaceEmoji("abc", "123", "qwerty", 5);
            FaceEmoji expE = new FaceEmoji("abc", "123", "qwerty", 5);
            Assert.AreEqual(e, expE);
        }
        [TestMethod]
        public void TestFaceEmojiClone()
        {
            FaceEmoji e = new FaceEmoji("abc", "123", "qwerty", 5);
            FaceEmoji expE = (FaceEmoji)e.Clone();
            Assert.AreEqual(e, expE);
        }
    }

    [TestClass]
    public class SmileEmojiTest
    {
        [TestMethod]
        public void TestFaceEmojiEmpty()
        {
            SmileEmoji e = new SmileEmoji();
            SmileEmoji expE = new SmileEmoji("Пустая эмоция", "Empty", "-_-", 0, "Нет причины");
            Assert.AreEqual(e, expE);
        }
        [TestMethod]
        public void TestFaceEmojiCopy()
        {
            SmileEmoji e = new SmileEmoji("abc", "123", "qwerty", 5, "zxc");
            SmileEmoji expE = new SmileEmoji(e);
            Assert.AreEqual(e, expE);
        }
        [TestMethod]
        public void TestFaceEmojiId()
        {
            SmileEmoji e = new SmileEmoji(1, "abc", "123", "qwerty", 5, "zxc");
            SmileEmoji expE = new SmileEmoji();
            expE.Id = 1;
            expE.Name = "abc";
            expE.Tag = "123";
            expE.Desc = "qwerty";
            expE.Str = 5;
            expE.Reason = "zxc";
            Assert.AreEqual(e, expE);
        }
        [TestMethod]
        public void TestFaceEmojiNegativeId()
        {
            SmileEmoji e = new SmileEmoji(-5, "abc", "123", "qwerty", 5, "zxc");
            SmileEmoji expE = new SmileEmoji();
            expE.Id = 0;
            expE.Name = "abc";
            expE.Tag = "123";
            expE.Desc = "qwerty";
            expE.Str = 5;
            expE.Reason = "zxc";
            Assert.AreEqual(e, expE);
        }
        [TestMethod]
        public void TestFaceEmojiRandomInit()
        {
            SmileEmoji e = new SmileEmoji();
            e.RandomInit();
            SmileEmoji expE = new SmileEmoji(e);
            Assert.AreEqual(e, expE);
        }
        [TestMethod]
        public void TestFaceEmojiEqual1()
        {
            SmileEmoji e = new SmileEmoji("abc", "123", "qwerty", 5, "zxc");
            int n = 100;
            Assert.AreNotEqual(e, n);
        }
        [TestMethod]
        public void TestFaceEmojiEqual2()
        {
            SmileEmoji e = new SmileEmoji("abc", "123", "qwerty", 5, "zxc");
            Assert.AreNotEqual(e, null);
        }
        [TestMethod]
        public void TestFaceEmojiEqual3()
        {
            SmileEmoji e = new SmileEmoji("abc", "123", "qwerty", 5, "zxc");
            SmileEmoji expE = new SmileEmoji("abc", "123", "qwerty", 5, "zxc");
            Assert.AreEqual(e, expE);
        }
        [TestMethod]
        public void TestFaceEmojiClone()
        {
            SmileEmoji e = new SmileEmoji("abc", "123", "qwerty", 5, "zxc");
            SmileEmoji expE = (SmileEmoji)e.Clone();
            Assert.AreEqual(e, expE);
        }
    }
    [TestClass]
    public class AnimalEmojiTest
    {
        [TestMethod]
        public void TestFaceEmojiEmpty()
        {
            AnimalEmoji e = new AnimalEmoji();
            AnimalEmoji expE = new AnimalEmoji("Пустая эмоция", "Empty", "Ктулху");
            Assert.AreEqual(e, expE);
        }
        [TestMethod]
        public void TestFaceEmojiCopy()
        {
            AnimalEmoji e = new AnimalEmoji("abc", "123", "чиновник");
            AnimalEmoji expE = new AnimalEmoji(e);
            Assert.AreEqual(e, expE);
        }
        [TestMethod]
        public void TestFaceEmojiId()
        {
            AnimalEmoji e = new AnimalEmoji(1, "abc", "123", "чиновник");
            AnimalEmoji expE = new AnimalEmoji();
            expE.Id = 1;
            expE.Name = "abc";
            expE.Tag = "123";
            expE.Animal = "чиновник";
            Assert.AreEqual(e, expE);
        }
        [TestMethod]
        public void TestFaceEmojiNegativeId()
        {
            AnimalEmoji e = new AnimalEmoji(-5, "abc", "123", "чиновник");
            AnimalEmoji expE = new AnimalEmoji();
            expE.Id = 0;
            expE.Name = "abc";
            expE.Tag = "123";
            expE.Animal = "чиновник";
            Assert.AreEqual(e, expE);
        }
        [TestMethod]
        public void TestFaceEmojiRandomInit()
        {
            AnimalEmoji e = new AnimalEmoji();
            e.RandomInit();
            AnimalEmoji expE = new AnimalEmoji(e);
            Assert.AreEqual(e, expE);
        }
        [TestMethod]
        public void TestFaceEmojiEqual1()
        {
            AnimalEmoji e = new AnimalEmoji("abc", "123", "чиновник");
            int n = 100;
            Assert.AreNotEqual(e, n);
        }
        [TestMethod]
        public void TestFaceEmojiEqual2()
        {
            AnimalEmoji e = new AnimalEmoji("abc", "123", "чиновник");
            Assert.AreNotEqual(e, null);
        }
        [TestMethod]
        public void TestFaceEmojiEqual3()
        {
            AnimalEmoji e = new AnimalEmoji("abc", "123", "чиновник");
            AnimalEmoji expE = new AnimalEmoji("abc", "123", "чиновник");
            Assert.AreEqual(e, expE);
        }
        [TestMethod]
        public void TestFaceEmojiClone()
        {
            AnimalEmoji e = new AnimalEmoji("abc", "123", "чиновник");
            AnimalEmoji expE = (AnimalEmoji)e.Clone();
            Assert.AreEqual(e, expE);
        }
    }
}
