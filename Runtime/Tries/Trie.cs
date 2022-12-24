using System.Collections.Generic;

namespace LiteNinja.WordCraft
{
  /// <summary>
  /// Trie is a data structure that efficiently stores and retrieves a dynamic set of strings.
  /// It is implemented as a tree-like structure where each node represents a character in a word,
  /// and the path from the root to the node represents the word itself.
  /// The Trie class provides methods for adding new words to the trie, checking if a given word is present in the trie,
  /// and checking if a given prefix is present in the trie.
  /// </summary>
  public class Trie
  {
    private readonly Node _root;

    public Trie()
    {
      _root = new Node();
    }

    /// <summary>
    /// Adds a new word to the trie.
    /// </summary>
    /// <param name="word">The word to be inserted into the trie.</param>
    public void Add(string word)
    {
      var current = _root;
      foreach (var c in word)
      {
        if (!current.Children.ContainsKey(c))
        {
          var node = new Node();
          current.Children.Add(c, node);
          current = node;
        }
        else
        {
          current = current.Children[c];
        }
      }

      current.IsWord = true;
    }

    /// <summary>
    /// Determines whether the trie contains a given word.
    /// </summary>
    /// <param name="word">The word to search for in the trie.</param>
    /// <returns>True if the trie contains the word, false otherwise.</returns>
    public bool Contains(string word)
    {
      return Traverse(word, out var current) && current.IsWord;
    }

    /// <summary>
    /// Determines whether the trie contains a given prefix.
    /// </summary>
    /// <param name="prefix">The prefix to search for in the trie.</param>
    /// <returns>True if the trie contains the prefix, false otherwise.</returns>
    public bool ContainsPrefix(string prefix)
    {
      var current = _root;
      return Traverse(prefix, out current);
    }

    /// <summary>
    /// Traverses the trie and returns the node corresponding to a given word or prefix.
    /// </summary>
    /// <param name="word">The word or prefix to search for in the trie.</param>
    /// <param name="current">An out parameter that will be set to the node corresponding to the word or prefix.</param>
    /// <returns>True if the trie contains the word or prefix, false otherwise.</returns>
    private bool Traverse(string word, out Node current)
    {
      current = _root;
      foreach (var c in word)
      {
        if (!current.Children.ContainsKey(c))
        {
          return false;
        }

        current = current.Children[c];
      }

      return true;
    }

    /// <summary>
    /// Represents a node in a trie data structure.
    /// </summary>
    private class Node
    {
      /// <summary>
      /// Gets or sets a value indicating whether the node represents the end of a word.
      /// </summary>
      public bool IsWord { get; set; }

      /// <summary>
      /// Gets a dictionary of child nodes indexed by the character they represent.
      /// </summary>
      public Dictionary<char, Node> Children { get; set; }

      /// <summary>
      /// Initializes a new instance of the <see cref="Node"/> class.
      /// </summary>
      public Node()
      {
        Children = new Dictionary<char, Node>();
      }
    }
  }
}