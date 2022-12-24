using System.Collections;
using System.Collections.Generic;
using LiteNinja.WordCraft;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class TrieTests
{
    [Test]
    public void TestAddAndContains()
    {
        var trie = new Trie();
        trie.Add("hello");
        trie.Add("world");
        trie.Add("hi");

        Assert.True(trie.Contains("hello"));
        Assert.True(trie.Contains("world"));
        Assert.True(trie.Contains("hi"));
        Assert.False(trie.Contains("hell"));
        Assert.False(trie.Contains("he"));
        Assert.False(trie.Contains("hi!"));
    }

    [Test]
    public void TestContainsPrefix()
    {
        var trie = new Trie();
        trie.Add("hello");
        trie.Add("world");
        trie.Add("hi");

        Assert.True(trie.ContainsPrefix("h"));
        Assert.True(trie.ContainsPrefix("he"));
        Assert.True(trie.ContainsPrefix("hel"));
        Assert.True(trie.ContainsPrefix("hell"));
        Assert.True(trie.ContainsPrefix("w"));
        Assert.True(trie.ContainsPrefix("wo"));
        Assert.True(trie.ContainsPrefix("hi"));
        Assert.False(trie.ContainsPrefix("h!"));
        Assert.False(trie.ContainsPrefix("h1"));
    }
}
