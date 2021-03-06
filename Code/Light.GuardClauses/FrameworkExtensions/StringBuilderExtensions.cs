﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace Light.GuardClauses.FrameworkExtensions
{
    /// <summary>
    /// This class provides extension methods for the <see cref="StringBuilder" /> class.
    /// </summary>
    public static class StringBuilderExtensions
    {
        /// <summary>
        /// Gets the default NewLineSeparator for <see cref="AppendItems{T}" /> and <see cref="AppendKeyValuePairs{TKey,TValue}" />. This value is ",{Environment.NewLine}".
        /// </summary>
        public static readonly string DefaultNewLineSeparator = ',' + Environment.NewLine;

        private static Func<object, string> _useSurroundingCharactersForItem = UseQuotationMarksForNonPrimitiveTypes;

        /// <summary>
        /// Gets or sets the delegate that determines which items are surrounded by special characters when <see cref="AppendItems{T}" /> or <see cref="AppendKeyValuePairs{TKey,TValue}" /> appends content to a string builder.
        /// This delegate points to the <see cref="UseQuotationMarksForNonPrimitiveTypes" /> method by default.
        /// </summary>
        public static Func<object, string> UseSurroundingCharactersForItem
        {
            get => _useSurroundingCharactersForItem;
            set => _useSurroundingCharactersForItem = value.MustNotBeNull();
        }

        /// <summary>
        /// Appends the string representations of the specified items to the string builder.
        /// </summary>
        /// <typeparam name="T">The type of the <paramref name="items" />.</typeparam>
        /// <param name="stringBuilder">The string builder where the items will be appended to.</param>
        /// <param name="items">The items to be appended.</param>
        /// <param name="itemSeparator">
        /// The characters used to separate the items. Defaults to ", " and is not appended after the
        /// last item.
        /// </param>
        /// <param name="emptyCollectionText">
        /// The text that is appended to the string builder when <paramref name="items" /> is
        /// empty. Defaults to "empty collection".
        /// </param>
        /// <returns>The string builder to enable method chaining.</returns>
        /// <exception cref="ArgumentNullException">Thrown when any of the parameters but <paramref name="emptyCollectionText" /> is null.</exception>
        public static StringBuilder AppendItems<T>(this StringBuilder stringBuilder, IEnumerable<T> items, string itemSeparator = ", ", string emptyCollectionText = "empty collection")
        {
            // ReSharper disable PossibleMultipleEnumeration
            stringBuilder.MustNotBeNull(nameof(stringBuilder));
            items.MustNotBeNull(nameof(items));
            itemSeparator.MustNotBeNull(nameof(itemSeparator));

            var itemsCount = items.Count();
            if (itemsCount == 0)
                return stringBuilder.Append(emptyCollectionText);

            var currentIndex = 0;
            foreach (var itemToAppend in items)
            {
                var surroundingCharacters = UseSurroundingCharactersForItem(itemToAppend);
                stringBuilder.Append(surroundingCharacters);
                stringBuilder.Append(itemToAppend.ToStringOrNull());
                stringBuilder.Append(surroundingCharacters);
                if (currentIndex < itemsCount - 1)
                    stringBuilder.Append(itemSeparator);
                else
                    break;

                currentIndex++;
            }

            return stringBuilder;
            // ReSharper restore PossibleMultipleEnumeration
        }

        /// <summary>
        /// Appends the string representation of the specified items to the string builder, using <see cref="DefaultNewLineSeparator" /> after each item but the last one, and the default empty collection text.
        /// </summary>
        /// <typeparam name="T">The type of the <paramref name="items" />.</typeparam>
        /// <param name="stringBuilder">The string builder where the items will be appended to.</param>
        /// <param name="items">The items to be appended.</param>
        /// <returns>The string builder to enable method chaining.</returns>
        /// <exception cref="ArgumentNullException">Thrown when any of the parameters is null.</exception>
        public static StringBuilder AppendItemsWithNewLine<T>(this StringBuilder stringBuilder, IEnumerable<T> items)
        {
            return stringBuilder.AppendItems(items, DefaultNewLineSeparator);
        }

        /// <summary>
        /// Appends the string representation of the specified key-value-pair to the string builder.
        /// </summary>
        /// <typeparam name="TKey">The type of the key.</typeparam>
        /// <typeparam name="TValue">The type of the value.</typeparam>
        /// <param name="stringBuilder">The string builder where the pair will be appended to.</param>
        /// <param name="key">The key of the key-value-pair.</param>
        /// <param name="value">The value of the key-value-pair.</param>
        /// <returns>The string builder to enable method chaining.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="stringBuilder" /> is null.</exception>
        public static StringBuilder AppendKeyValuePair<TKey, TValue>(this StringBuilder stringBuilder, TKey key, TValue value)
        {
            stringBuilder.MustNotBeNull(nameof(stringBuilder));

            stringBuilder.Append('[');
            var keySurroundingCharacters = UseSurroundingCharactersForItem(key);
            stringBuilder.Append(keySurroundingCharacters)
                         .Append(key)
                         .Append(keySurroundingCharacters)
                         .Append("] = ");

            var valueSurroundingCharacters = UseSurroundingCharactersForItem(value);
            stringBuilder.Append(valueSurroundingCharacters)
                         .Append(value.ToStringOrNull())
                         .Append(valueSurroundingCharacters);

            return stringBuilder;
        }

        /// <summary>
        /// Appends the string reprensentations of the keys and values of the specified dictionary to the string builder.
        /// </summary>
        /// <typeparam name="TKey">The key type of the dictionary.</typeparam>
        /// <typeparam name="TValue">The value type of the dictionary.</typeparam>
        /// <param name="stringBuilder">The string builder where the pairs will be appended to.</param>
        /// <param name="dictionary">The dictionary whose keys and values will be appended.</param>
        /// <param name="pairSeparator">
        /// The characters used to separate the entries. Defaults to ", " and is not appended after the last key-value-pair.
        /// </param>
        /// <param name="emptyDictionaryText">
        /// The text that is appended to the string builder when <paramref name="dictionary" /> is empty. Defaults to "empty dictionary".
        /// </param>
        /// <returns>The string builder to enable method chaining.</returns>
        /// <exception cref="ArgumentNullException">Thrown when any of the parameters but <paramref name="emptyDictionaryText" /> is null.</exception>
        public static StringBuilder AppendKeyValuePairs<TKey, TValue>(this StringBuilder stringBuilder, IDictionary<TKey, TValue> dictionary, string pairSeparator = ", ", string emptyDictionaryText = "empty dictionary")
        {
            stringBuilder.MustNotBeNull(nameof(stringBuilder));
            dictionary.MustNotBeNull(nameof(dictionary));
            pairSeparator.MustNotBeNull(nameof(pairSeparator));

            if (dictionary.Count == 0)
                return stringBuilder.Append(emptyDictionaryText);

            var currentIndex = 0;
            foreach (var keyValuePair in dictionary)
            {
                stringBuilder.AppendKeyValuePair(keyValuePair.Key, keyValuePair.Value);

                if (currentIndex < dictionary.Count - 1)
                    stringBuilder.Append(pairSeparator);
                else
                    break;

                currentIndex++;
            }

            return stringBuilder;
        }

        /// <summary>
        /// Appends the string representation of the keys and values of the specified dictionary to the string builder, using <see cref="DefaultNewLineSeparator" /> after each pair but the last one, and the default empty dictionary text.
        /// </summary>
        /// <typeparam name="TKey">The key type of the dictionary.</typeparam>
        /// <typeparam name="TValue">The value type of the dictionary.</typeparam>
        /// <param name="stringBuilder">The string builder where the pairs will be appended to.</param>
        /// <param name="dictionary">The dictionary whose key-value-pairs will be appended.</param>
        /// <returns>The string builder to enable method chaining.</returns>
        /// <exception cref="ArgumentNullException">Occurs when any of the parameters is null.</exception>
        public static StringBuilder AppendKeyValuePairsWithNewLine<TKey, TValue>(this StringBuilder stringBuilder, IDictionary<TKey, TValue> dictionary)
        {
            return stringBuilder.AppendKeyValuePairs(dictionary, DefaultNewLineSeparator);
        }

        /// <summary>
        /// Returns the string reprensentation of item or nullText if item is null.
        /// </summary>
        /// <typeparam name="T">The type of the item.</typeparam>
        /// <param name="item">The item whose string representation should be returned.</param>
        /// <param name="nullText">The text that is returned when item is null (defaults to "null").</param>
        /// <returns>The string representation of item, or nullText.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string ToStringOrNull<T>(this T item, string nullText = "null")=> item == null ? nullText : item.ToString();

        /// <summary>
        /// This method returns quotation marks for all types that are not primitive numerics (like e.g. int, long, short, uint, etc.) or types regarding dates and times (DateTime, DateTimeOffset, TimeSpan).
        /// For the latter types, an empty string is returned. This method is not supposed to be called by you directly, but is the default value for <see cref="UseSurroundingCharactersForItem" />.
        /// </summary>
        public static string UseQuotationMarksForNonPrimitiveTypes(object value)
        {
            if (value == null)
                return string.Empty;

            var type = value.GetType();
            if (type == typeof(int) ||
                type == typeof(long) ||
                type == typeof(short) ||
                type == typeof(sbyte) ||
                type == typeof(uint) ||
                type == typeof(ulong) ||
                type == typeof(ushort) ||
                type == typeof(byte) ||
                type == typeof(bool) ||
                type == typeof(double) ||
                type == typeof(decimal) ||
                type == typeof(float) ||
                type == typeof(DateTime) ||
                type == typeof(DateTimeOffset) ||
                type == typeof(TimeSpan))
                return string.Empty;

            return "\"";
        }

        /// <summary>
        /// Appends the content of the collection with the specified header line to the string builder.
        /// Each item is on a new line.
        /// </summary>
        /// <typeparam name="T">The item type of the collection.</typeparam>
        /// <param name="stringBuilder">The string builder that the content is appended to.</param>
        /// <param name="collection">The collection whose items will be appended to the string builder.</param>
        /// <param name="headerLine">The string that will be placed before the actual items as a header.</param>
        /// <returns>The string builder for method chaining.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="stringBuilder" /> or <paramref name="collection" />is null.</exception>
        public static StringBuilder AppendCollectionContent<T>(this StringBuilder stringBuilder, IEnumerable<T> collection, string headerLine = "Actual content of the collection:")
        {
            return stringBuilder.MustNotBeNull(nameof(stringBuilder))
                                .AppendLine(headerLine)
                                .AppendItemsWithNewLine(collection);
        }

        /// <summary>
        /// Appends the content of the dictionary with the specified header line to the string builder.
        /// Each key-value-pair is on a new line.
        /// </summary>
        /// <typeparam name="TKey">The type of the keys of the dictionary.</typeparam>
        /// <typeparam name="TValue">The type of the values of the dictionary.</typeparam>
        /// <param name="stringBuilder">The string builder the content is appended to.</param>
        /// <param name="dictionary">The dictionary whose key-value-pairs will be appended to the string builder.</param>
        /// <param name="headerLine">The string that will be placed before the actual items as the header.</param>
        /// <returns>The string builder for method chaining.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="stringBuilder" /> or <paramref name="dictionary" /> is null.</exception>
        public static StringBuilder AppendDictionaryContent<TKey, TValue>(this StringBuilder stringBuilder, IDictionary<TKey, TValue> dictionary, string headerLine = "Actual content of the dictionary:")
        {
            return stringBuilder.MustNotBeNull(nameof(stringBuilder))
                                .AppendLine(headerLine)
                                .AppendKeyValuePairsWithNewLine(dictionary);
        }

        /// <summary>
        /// Appends the messages of the <paramref name="exception" /> and its nested exceptions to the
        /// specified <paramref name="stringBuilder" />.
        /// </summary>
        /// <exception cref="ArgumentNullException">Thrown when any parameter is null.</exception>
        public static StringBuilder AppendExceptionMessages(this StringBuilder stringBuilder, Exception exception)
        {
            stringBuilder.MustNotBeNull();
            exception.MustNotBeNull();

            var currentException = exception;
            while (true)
            {
                stringBuilder.AppendLine(currentException.Message);
                if (currentException.InnerException != null)
                    stringBuilder.AppendLine();
                else
                    return stringBuilder;
                currentException = exception.InnerException;
            }
        }

        /// <summary>
        /// Formats all messages of the <paramref name="exception" /> and its nested exceptions into
        /// a single string.
        /// </summary>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="exception" /> is null.</exception>
        public static string GetAllExceptionMessages(this Exception exception)
        {
            return new StringBuilder().AppendExceptionMessages(exception).ToString();
        }
    }
}