using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RailswareMailtrap.Infrastructure.Helper.ExceptionHandler
{
    public static class Ensure
    {
        /// <summary>
        /// Ensures that the value of a parameter is between a minimum and a maximum value
        /// </summary>
        /// <param name="value">The value of the parameter</param>
        /// <param name="min">The minimum value</param>
        /// <param name="max">The maximum value</param>
        /// <param name="paramName">The name of the parameter</param>
        /// <typeparam name="T">Type type of the value</typeparam>
        /// <returns>The value of the parameter</returns>
        public static T IsBetween<T>(T value, T min, T max, string paramName) where T : IComparable<T>
        {
            if (value.CompareTo(min) < 0 || value.CompareTo(max) > 0)
                throw new ArgumentOutOfRangeException(paramName, string.Format("Value is not between {0} and {1}: {2}.", min, max, value));
            return value;
        }

        /// <summary>
        /// Ensures that the value of a parameter is equal to a comparand
        /// </summary>
        /// <param name="value">The value of the parameter</param>
        /// <param name="comparand">The comparand</param>
        /// <param name="paramName">The name of the parameter</param>
        /// <typeparam name="T">Type type of the value</typeparam>
        /// <returns>The value of the parameter</returns>
        public static T IsEqualTo<T>(T value, T comparand, string paramName) where T : IEquatable<T> => value.Equals(comparand) ? value : throw new ArgumentException(string.Format("Value is not equal to {0}: {1}.", comparand, value), paramName);

        /// <summary>
        /// Ensures that the value of a parameter is equal to a comparand
        /// </summary>
        /// <param name="value">The value of the parameter</param>
        /// <param name="comparand">The comparand</param>
        /// <param name="paramName">The name of the parameter</param>
        /// <typeparam name="T">Type type of the value</typeparam>
        /// <returns>The value of the parameter</returns>
        public static T IsEqualTo<T>(T value, object comparand, string paramName) => value.Equals(comparand) ? value : throw new ArgumentException(string.Format("Value is not equal to {0}: {1}.", comparand, value), paramName);

        /// <summary>
        /// Ensures that the value of a parameter is greater than a comparand
        /// </summary>
        /// <param name="value">The value of the parameter</param>
        /// <param name="comparand">The comparand</param>
        /// <param name="paramName">The name of the parameter</param>
        /// <typeparam name="T">Type type of the value</typeparam>
        /// <returns>The value of the parameter</returns>
        public static T IsGreaterThan<T>(T value, T comparand, string paramName) where T : IComparable<T> => value.CompareTo(comparand) > 0 ? value : throw new ArgumentOutOfRangeException(paramName, string.Format("Value is not greater than {0}: {1}.", comparand, value));

        /// <summary>
        /// Ensures that the value of a parameter is greater than or equal to a comparand
        /// </summary>
        /// <param name="value">The value of the parameter</param>
        /// <param name="comparand">The comparand</param>
        /// <param name="paramName">The name of the parameter</param>
        /// <typeparam name="T">Type type of the value</typeparam>
        /// <returns>The value of the parameter</returns>
        public static T IsGreaterThanOrEqualTo<T>(T value, T comparand, string paramName) where T : IComparable<T> => value.CompareTo(comparand) >= 0 ? value : throw new ArgumentOutOfRangeException(paramName, string.Format("Value is not greater than or equal to {0}: {1}.", comparand, value));

        /// <summary>
        /// Ensures that the value of a parameter is lower than a comparand
        /// </summary>
        /// <param name="value">The value of the parameter</param>
        /// <param name="comparand">The comparand</param>
        /// <param name="paramName">The name of the parameter</param>
        /// <typeparam name="T">Type type of the value</typeparam>
        /// <returns>The value of the parameter</returns>
        public static T IsLowerThan<T>(T value, T comparand, string paramName) where T : IComparable<T> => value.CompareTo(comparand) < 0 ? value : throw new ArgumentOutOfRangeException(paramName, string.Format("Value is not lower than {0}: {1}.", comparand, value));

        /// <summary>
        /// Ensures that the value of a parameter is lower than or equal to a comparand
        /// </summary>
        /// <param name="value">The value of the parameter</param>
        /// <param name="comparand">The comparand</param>
        /// <param name="paramName">The name of the parameter</param>
        /// <typeparam name="T">Type type of the value</typeparam>
        /// <returns>The value of the parameter</returns>
        public static T IsLowerThanOrEqualTo<T>(T value, T comparand, string paramName) where T : IComparable<T> => value.CompareTo(comparand) <= 0 ? value : throw new ArgumentOutOfRangeException(paramName, string.Format("Value is not lower than or equal to {0}: {1}.", comparand, value));

        /// <summary>
        /// Ensures that the value of a parameter is greater than or equal to zero
        /// </summary>
        /// <param name="value">The value of the parameter</param>
        /// <param name="paramName">The name of the parameter</param>
        /// <returns>The value of the parameter</returns>
        public static int IsGreaterThanOrEqualToZero(int value, string paramName) => value >= 0 ? value : throw new ArgumentOutOfRangeException(paramName, string.Format("Value is not greater than or equal to 0: {0}.", value));

        /// <summary>
        /// Ensures that the value of a parameter is greater than or equal to zero
        /// </summary>
        /// <param name="value">The value of the parameter</param>
        /// <param name="paramName">The name of the parameter</param>
        /// <returns>The value of the parameter</returns>
        public static long IsGreaterThanOrEqualToZero(long value, string paramName) => value >= 0L ? value : throw new ArgumentOutOfRangeException(paramName, string.Format("Value is not greater than or equal to 0: {0}.", value));

        /// <summary>
        /// Ensures that the value of a parameter is greater than or equal to zero
        /// </summary>
        /// <param name="value">The value of the parameter</param>
        /// <param name="paramName">The name of the parameter</param>
        /// <returns>The value of the parameter</returns>
        public static decimal IsGreaterThanOrEqualToZero(decimal value, string paramName) => !(value < 0M) ? value : throw new ArgumentOutOfRangeException(paramName, string.Format("Value is not greater than or equal to 0: {0}.", value));

        /// <summary>
        /// Ensures that the value of a parameter is greater than or equal to zero
        /// </summary>
        /// <param name="value">The value of the parameter</param>
        /// <param name="paramName">The name of the parameter</param>
        /// <returns>The value of the parameter</returns>
        public static TimeSpan IsGreaterThanOrEqualToZero(TimeSpan value, string paramName) => !(value < TimeSpan.Zero) ? value : throw new ArgumentOutOfRangeException(paramName, string.Format("Value is not greater than or equal to zero: {0}.", value));

        /// <summary>
        /// Ensures that the value of a parameter is greater than zero
        /// </summary>
        /// <param name="value">The value of the parameter</param>
        /// <param name="paramName">The name of the parameter</param>
        /// <returns>The value of the parameter</returns>
        public static int IsGreaterThanZero(int value, string paramName) => value > 0 ? value : throw new ArgumentOutOfRangeException(paramName, string.Format("Value is not greater than zero: {0}.", value));

        /// <summary>
        /// Ensures that the value of a parameter is greater than zero
        /// </summary>
        /// <param name="value">The value of the parameter</param>
        /// <param name="paramName">The name of the parameter</param>
        /// <returns>The value of the parameter</returns>
        public static long IsGreaterThanZero(long value, string paramName) => value > 0L ? value : throw new ArgumentOutOfRangeException(paramName, string.Format("Value is not greater than zero: {0}.", value));

        /// <summary>
        /// Ensures that the value of a parameter is greater than zero
        /// </summary>
        /// <param name="value">The value of the parameter</param>
        /// <param name="paramName">The name of the parameter</param>
        /// <returns>The value of the parameter</returns>
        public static decimal IsGreaterThanZero(decimal value, string paramName) => !(value <= 0M) ? value : throw new ArgumentOutOfRangeException(paramName, string.Format("Value is not greater than zero: {0}.", value));

        /// <summary>
        /// Ensures that the value of a parameter is greater than zero
        /// </summary>
        /// <param name="value">The value of the parameter</param>
        /// <param name="paramName">The name of the parameter</param>
        /// <returns>The value of the parameter</returns>
        public static TimeSpan IsGreaterThanZero(TimeSpan value, string paramName) => !(value <= TimeSpan.Zero) ? value : throw new ArgumentOutOfRangeException(paramName, string.Format("Value is not greater than zero: {0}.", value));

        /// <summary>
        /// Ensures that the value of a parameter is infinite or greater than or equal to zero
        /// </summary>
        /// <param name="value">The value of the parameter</param>
        /// <param name="paramName">The name of the parameter</param>
        /// <returns>The value of the parameter</returns>
        public static TimeSpan IsInfiniteOrGreaterThanOrEqualToZero(
          TimeSpan value,
          string paramName)
        {
            if (value < TimeSpan.Zero && value != Timeout.InfiniteTimeSpan)
                throw new ArgumentOutOfRangeException(paramName, string.Format("Value is not infinite or greater than or equal to zero: {0}.", value));
            return value;
        }

        /// <summary>
        /// Ensures that the value of a parameter is infinite or greater than zero
        /// </summary>
        /// <param name="value">The value of the parameter</param>
        /// <param name="paramName">The name of the parameter</param>
        /// <returns>The value of the parameter</returns>
        public static TimeSpan IsInfiniteOrGreaterThanZero(TimeSpan value, string paramName)
        {
            if (value != Timeout.InfiniteTimeSpan && value <= TimeSpan.Zero)
                throw new ArgumentOutOfRangeException(paramName, string.Format("Value is not infinite or greater than zero: {0}.", value));
            return value;
        }

        /// <summary>Ensures that the value of a parameter is not null</summary>
        /// <param name="value">The value of the parameter</param>
        /// <param name="paramName">The name of the parameter</param>
        /// <typeparam name="T">Type type of the value</typeparam>
        /// <returns>The value of the parameter</returns>
        public static T IsNotNull<T>(T value, string paramName) where T : class => value != null ? value : throw new ArgumentNullException(paramName, "Value cannot be null.");

        /// <summary>
        /// Ensures that the value of a parameter is not null or empty
        /// </summary>
        /// <param name="value">The value of the parameter</param>
        /// <param name="paramName">The name of the parameter</param>
        /// <returns>The value of the parameter</returns>
        public static string IsNotNullOrEmpty(string value, string paramName)
        {
            switch (value)
            {
                case "":
                    throw new ArgumentException("Value cannot be empty.", paramName);
                case null:
                    throw new ArgumentNullException(paramName);
                default:
                    return value;
            }
        }

        /// <summary>
        /// Ensures that the value of a parameter is not null or empty/whitespace
        /// </summary>
        /// <param name="value">The value of the parameter</param>
        /// <param name="paramName">The name of the parameter</param>
        /// <returns>The value of the parameter</returns>
        public static string IsNotNullOrWhiteSpace(string value, string paramName)
        {
            if (value == null)
                throw new ArgumentNullException(paramName);
            return !string.IsNullOrWhiteSpace(value) ? value : throw new ArgumentException("Value cannot be empty or contain only whitespace characters.", paramName);
        }

        /// <summary>Ensures that the value of a parameter is null</summary>
        /// <param name="value">The value of the parameter</param>
        /// <param name="paramName">The name of the parameter</param>
        /// <typeparam name="T">Type type of the value.</typeparam>
        /// <returns>The value of the parameter</returns>
        public static T IsNull<T>(T value, string paramName) where T : class => value == null ? value : throw new ArgumentException("Value must be null.", paramName);

        /// <summary>
        /// Ensures that the value of a parameter is null or greater than a comparand
        /// </summary>
        /// <param name="value">The value of the parameter</param>
        /// <param name="comparand">The comparand</param>
        /// <param name="paramName">The name of the parameter</param>
        /// <typeparam name="T">Type type of the value</typeparam>
        /// <returns>The value of the parameter</returns>
        public static T? IsNullOrGreaterThan<T>(T? value, T comparand, string paramName) where T : struct, IComparable<T>
        {
            if (value.HasValue)
                IsGreaterThan(value.Value, comparand, paramName);
            return value;
        }

        /// <summary>
        /// Ensures that the value of a parameter is null or greater than a comparand
        /// </summary>
        /// <param name="value">The value of the parameter</param>
        /// <param name="comparand">The comparand</param>
        /// <param name="paramName">The name of the parameter</param>
        /// <typeparam name="T">Type type of the value.</typeparam>
        /// <returns>The value of the parameter</returns>
        public static T IsNullOrGreaterThan<T>(T value, T comparand, string paramName) where T : class, IComparable<T>
        {
            if (value != null)
                IsGreaterThan(value, comparand, paramName);
            return value;
        }

        /// <summary>
        /// Ensures that the value of a parameter is null or greater than or equal to a comparand
        /// </summary>
        /// <param name="value">The value of the parameter</param>
        /// <param name="comparand">The comparand</param>
        /// <param name="paramName">The name of the parameter</param>
        /// <typeparam name="T">Type type of the value</typeparam>
        /// <returns>The value of the parameter</returns>
        public static T? IsNullOrGreaterThanOrEqualTo<T>(T? value, T comparand, string paramName) where T : struct, IComparable<T>
        {
            if (value.HasValue)
                IsGreaterThanOrEqualTo(value.Value, comparand, paramName);
            return value;
        }

        /// <summary>
        /// Ensures that the value of a parameter is null or greater than or equal to a comparand
        /// </summary>
        /// <param name="value">The value of the parameter</param>
        /// <param name="comparand">The comparand</param>
        /// <param name="paramName">The name of the parameter</param>
        /// <typeparam name="T">Type type of the value</typeparam>
        /// <returns>The value of the parameter</returns>
        public static T IsNullOrGreaterThanOrEqualTo<T>(T value, T comparand, string paramName) where T : class, IComparable<T>
        {
            if (value != null)
                IsGreaterThanOrEqualTo(value, comparand, paramName);
            return value;
        }

        /// <summary>
        /// Ensures that the value of a parameter is null or greater than or equal to zero
        /// </summary>
        /// <param name="value">The value of the parameter</param>
        /// <param name="paramName">The name of the parameter</param>
        /// <returns>The value of the parameter</returns>
        public static int? IsNullOrGreaterThanOrEqualToZero(int? value, string paramName)
        {
            if (value.HasValue)
                IsGreaterThanOrEqualToZero(value.Value, paramName);
            return value;
        }

        /// <summary>
        /// Ensures that the value of a parameter is null or greater than or equal to zero
        /// </summary>
        /// <param name="value">The value of the parameter</param>
        /// <param name="paramName">The name of the parameter</param>
        /// <returns>The value of the parameter</returns>
        public static long? IsNullOrGreaterThanOrEqualToZero(long? value, string paramName)
        {
            if (value.HasValue)
                IsGreaterThanOrEqualToZero(value.Value, paramName);
            return value;
        }

        /// <summary>
        /// Ensures that the value of a parameter is null or greater than or equal to zero
        /// </summary>
        /// <param name="value">The value of the parameter</param>
        /// <param name="paramName">The name of the parameter</param>
        /// <returns>The value of the parameter</returns>
        public static decimal? IsNullOrGreaterThanOrEqualToZero(decimal? value, string paramName)
        {
            if (value.HasValue)
                IsGreaterThanOrEqualToZero(value.Value, paramName);
            return value;
        }

        /// <summary>
        /// Ensures that the value of a parameter is null or greater than zero
        /// </summary>
        /// <param name="value">The value of the parameter</param>
        /// <param name="paramName">The name of the parameter</param>
        /// <returns>The value of the parameter</returns>
        public static int? IsNullOrGreaterThanZero(int? value, string paramName)
        {
            if (value.HasValue)
                IsGreaterThanZero(value.Value, paramName);
            return value;
        }

        /// <summary>
        /// Ensures that the value of a parameter is null or greater than zero
        /// </summary>
        /// <param name="value">The value of the parameter</param>
        /// <param name="paramName">The name of the parameter</param>
        /// <returns>The value of the parameter</returns>
        public static long? IsNullOrGreaterThanZero(long? value, string paramName)
        {
            if (value.HasValue)
                IsGreaterThanZero(value.Value, paramName);
            return value;
        }

        /// <summary>
        /// Ensures that the value of a parameter is null or greater than zero
        /// </summary>
        /// <param name="value">The value of the parameter</param>
        /// <param name="paramName">The name of the parameter</param>
        /// <returns>The value of the parameter</returns>
        public static decimal? IsNullOrGreaterThanZero(decimal? value, string paramName)
        {
            if (value.HasValue)
                IsGreaterThanZero(value.Value, paramName);
            return value;
        }

        /// <summary>
        /// Ensures that the value of a parameter is null or greater than zero
        /// </summary>
        /// <param name="value">The value of the parameter</param>
        /// <param name="paramName">The name of the parameter</param>
        /// <returns>The value of the parameter</returns>
        public static TimeSpan? IsNullOrGreaterThanZero(TimeSpan? value, string paramName)
        {
            if (value.HasValue)
                IsGreaterThanZero(value.Value, paramName);
            return value;
        }

        /// <summary>
        /// Ensures that the value of a parameter is null, or infinite, or greater than or equal to zero
        /// </summary>
        /// <param name="value">The value of the parameter</param>
        /// <param name="paramName">The name of the parameter</param>
        /// <returns>The value of the parameter</returns>
        public static TimeSpan? IsNullOrInfiniteOrGreaterThanOrEqualToZero(
          TimeSpan? value,
          string paramName)
        {
            if (value.HasValue && value.Value < TimeSpan.Zero && value.Value != Timeout.InfiniteTimeSpan)
                throw new ArgumentOutOfRangeException(paramName, string.Format("Value is not null or infinite or greater than or equal to zero: {0}.", value));
            return value;
        }

        /// <summary>
        /// Ensures that the value of a parameter is null or not empty
        /// </summary>
        /// <param name="value">The value of the parameter</param>
        /// <param name="paramName">The name of the parameter</param>
        /// <returns>The value of the parameter</returns>
        public static string IsNullOrNotEmpty(string value, string paramName) => value == null || value != "" ? value : throw new ArgumentException("Value cannot be empty.", paramName);

        /// <summary>
        /// Ensures that the value of a parameter is null or a valid timeout
        /// </summary>
        /// <param name="value">The value of the parameter</param>
        /// <param name="paramName">The name of the parameter</param>
        /// <returns>The value of the parameter</returns>
        public static TimeSpan? IsNullOrValidTimeout(TimeSpan? value, string paramName)
        {
            if (value.HasValue)
                IsValidTimeout(value.Value, paramName);
            return value;
        }

        /// <summary>
        /// Ensures that the value of a parameter is a valid timeout
        /// </summary>
        /// <param name="value">The value of the parameter</param>
        /// <param name="paramName">The name of the parameter</param>
        /// <returns>The value of the parameter</returns>
        public static TimeSpan IsValidTimeout(TimeSpan value, string paramName)
        {
            if (value < TimeSpan.Zero && value != Timeout.InfiniteTimeSpan)
                throw new ArgumentException(string.Format("Invalid timeout: {0}.", value), paramName);
            return value;
        }

        /// <summary>Ensures that an assertion is true</summary>
        /// <param name="assertion">The assertion</param>
        /// <param name="message">The message to use with the exception that is thrown if the assertion is false</param>
        public static void That(bool assertion, string message)
        {
            if (!assertion)
                throw new ArgumentException(message);
        }

        /// <summary>Ensures that an assertion is true</summary>
        /// <param name="assertion">The assertion</param>
        /// <param name="message">The message to use with the exception that is thrown if the assertion is false</param>
        /// <param name="paramName">The parameter name</param>
        public static void That(bool assertion, string message, string paramName)
        {
            if (!assertion)
                throw new ArgumentException(message, paramName);
        }

        /// <summary>
        /// Ensures that the value of a parameter meets an assertion
        /// </summary>
        /// <param name="value">The value of the parameter</param>
        /// <param name="assertion">The assertion</param>
        /// <param name="paramName">The name of the parameter</param>
        /// <param name="message">The message to use with the exception that is thrown if the assertion is false</param>
        /// <typeparam name="T">Type type of the value</typeparam>
        /// <returns>The value of the parameter</returns>
        public static T That<T>(T value, Func<T, bool> assertion, string message, string paramName) => assertion(value) ? value : throw new ArgumentException(message, paramName);

        /// <summary>Ensures that the collection is not null or empty</summary>
        /// <param name="collection">The collection of items</param>
        /// <param name="paramName">The name of the parameter</param>
        public static void CollectionIsNotNullOrEmpty<T>(ICollection<T> collection, string paramName)
        {
            IsNotNull(collection, paramName);
            if (collection.Count == 0)
                throw new ArgumentOutOfRangeException(paramName, "Collection cannot be empty.");
        }

        /// <summary>Ensures that the all collection items is not null</summary>
        /// <typeparam name="T">The type of the collection items</typeparam>
        /// <param name="collection">The collection of items</param>
        /// <param name="paramName">The name of the parameter</param>
        /// <returns>The value of the parameter</returns>
        public static void CollectionItemsIsNotNull<T>(ICollection<T> collection, string paramName) where T : class
        {
            if (collection != null && collection.Any(x => x == null))
                throw new ArgumentException(paramName, "Items in collection " + paramName + " cannot be null.");
        }

        /// <summary>
        /// Ensures that the the collection is not null or empty and all collection items is not null
        /// </summary>
        /// <typeparam name="T">The type of the collection items.</typeparam>
        /// <param name="collection">The collection of items</param>
        /// <param name="paramName">The name of the parameter</param>
        public static void CollectionIsNotNullOrEmptyAndItemsIsNotNull<T>(
          ICollection<T> collection,
          string paramName)
          where T : class
        {
            CollectionIsNotNullOrEmpty(collection, paramName);
            CollectionItemsIsNotNull(collection, paramName);
        }

        /// <summary>
        /// Ensures that the the collection is not null or empty and all collection items is not null
        /// </summary>
        /// <typeparam name="T">The type of the collection items</typeparam>
        /// <param name="collection">The collection of items</param>
        /// <param name="paramName">The name of the parameter</param>
        public static void CollectionIsNotNullAndItemsIsNotNull<T>(
          ICollection<T> collection,
          string paramName)
          where T : class
        {
            IsNotNull(collection, paramName);
            CollectionItemsIsNotNull(collection, paramName);
        }

        /// <summary>
        /// Ensures that the all collection items is greater than a comparand
        /// </summary>
        /// <typeparam name="T">The type of the collection items</typeparam>
        /// <param name="collection">The collection of items</param>
        /// <param name="comparand">The comparand</param>
        /// <param name="paramName">The name of the parameter</param>
        public static void CollectionItemsIsGreaterThan<T>(
          ICollection<T> collection,
          T comparand,
          string paramName)
          where T : IComparable<T>
        {
            if (collection.Any(x => x.CompareTo(comparand) <= 0))
                throw new ArgumentOutOfRangeException(paramName, string.Format("Items in collection cannot be lower than {0}.", comparand));
        }

        /// <summary>
        /// Ensures that the all collection items is greater than zero
        /// </summary>
        /// <param name="collection">The collection of items</param>
        /// <param name="paramName">The name of the parameter</param>
        public static void CollectionItemsIsGreaterThanZero(
          ICollection<long> collection,
          string paramName)
        {
            if (collection.Any(x => x <= 0L))
                throw new ArgumentOutOfRangeException(paramName, "Items in collection cannot be lower than zero.");
        }

        /// <summary>
        /// Ensures that the all collection items is greater than zero
        /// </summary>
        /// <param name="collection">The collection of items</param>
        /// <param name="paramName">The name of the parameter</param>
        public static void CollectionItemsIsGreaterThanZero(
          ICollection<int> collection,
          string paramName)
        {
            if (collection.Any(x => x <= 0))
                throw new ArgumentOutOfRangeException(paramName, "Items in collection cannot be lower than zero.");
        }

        /// <summary>Ensures that the collection is not null or empty</summary>
        /// <param name="collection">The collection of items</param>
        /// <param name="paramName">The name of the parameter</param>
        /// <returns>The value of the parameter</returns>
        public static void ReadOnlyCollectionIsNotNullOrEmpty<T>(
          IReadOnlyCollection<T> collection,
          string paramName)
        {
            IsNotNull(collection, paramName);
            if (collection.Count == 0)
                throw new ArgumentOutOfRangeException(paramName, "Collection cannot be empty.");
        }

        /// <summary>Ensures that the all collection items is not null</summary>
        /// <typeparam name="T">The type of the collection items</typeparam>
        /// <param name="collection">The collection of items</param>
        /// <param name="paramName">The name of the parameter</param>
        public static void ReadOnlyCollectionItemsIsNotNull<T>(
          IReadOnlyCollection<T> collection,
          string paramName)
          where T : class
        {
            if (collection != null && collection.Any(x => x == null))
                throw new ArgumentException(paramName, "Items in collection " + paramName + " cannot be null.");
        }

        /// <summary>
        /// Ensures that the the collection is not null or empty and all collection items is not null
        /// </summary>
        /// <typeparam name="T">The type of the collection items</typeparam>
        /// <param name="collection">The collection of items</param>
        /// <param name="paramName">The name of the parameter</param>
        public static void ReadOnlyCollectionIsNotNullOrEmptyAndItemsIsNotNull<T>(
          IReadOnlyCollection<T> collection,
          string paramName)
          where T : class
        {
            ReadOnlyCollectionIsNotNullOrEmpty(collection, paramName);
            ReadOnlyCollectionItemsIsNotNull(collection, paramName);
        }

        /// <summary>
        /// Ensures that the the collection is not null or empty and all collection items is not null
        /// </summary>
        /// <typeparam name="T">The type of the collection items</typeparam>
        /// <param name="collection">The collection of items</param>
        /// <param name="paramName">The name of the parameter</param>
        /// <returns>The value of the parameter</returns>
        public static void ReadOnlyCollectionIsNotNullAndItemsIsNotNull<T>(
          IReadOnlyCollection<T> collection,
          string paramName)
          where T : class
        {
            IsNotNull(collection, paramName);
            ReadOnlyCollectionItemsIsNotNull(collection, paramName);
        }

        /// <summary>
        /// Ensures that the all collection items is greater than a comparand
        /// </summary>
        /// <typeparam name="T">The type of the collection items</typeparam>
        /// <param name="collection">The collection of items</param>
        /// <param name="comparand">The comparand</param>
        /// <param name="paramName">The name of the parameter</param>
        public static void ReadOnlyCollectionItemsIsGreaterThan<T>(
          IReadOnlyCollection<T> collection,
          T comparand,
          string paramName)
          where T : IComparable<T>
        {
            if (collection.Any(x => x.CompareTo(comparand) <= 0))
                throw new ArgumentOutOfRangeException(paramName, string.Format("Items in collection cannot be lower than {0}.", comparand));
        }

        /// <summary>
        /// Ensures that the all collection items is greater than zero
        /// </summary>
        /// <param name="collection">The collection of items</param>
        /// <param name="paramName">The name of the parameter</param>
        /// <returns>The value of the parameter</returns>
        public static void ReadOnlyCollectionItemsIsGreaterThanZero(
          IReadOnlyCollection<long> collection,
          string paramName)
        {
            if (collection.Any(x => x <= 0L))
                throw new ArgumentOutOfRangeException(paramName, "Items in collection cannot be lower than zero.");
        }

        /// <summary>
        /// Ensures that the all collection items is greater than zero.
        /// </summary>
        /// <param name="collection">The collection of items</param>
        /// <param name="paramName">The name of the parameter</param>
        /// <returns>The value of the parameter.</returns>
        public static void ReadOnlyCollectionItemsIsGreaterThanZero(
          IReadOnlyCollection<int> collection,
          string paramName)
        {
            if (collection.Any(x => x <= 0))
                throw new ArgumentOutOfRangeException(paramName, "Items in collection cannot be lower than zero.");
        }

        /// <summary>
        /// Ensures that the exception message is not null or empty/whitespace 
        /// </summary>
        /// <param name="message">The exception message</param>
        /// <returns>The <paramref name="message"/></returns>
        public static string MessageIsNotNullOrWhiteSpace(string message)
        {
            if (message == null) throw new ArgumentNullException(nameof(message));
            if (string.IsNullOrWhiteSpace(message)) throw new ArgumentException(@"Value cannot be empty or contain only whitespace characters.", nameof(message));
            return message;
        }

        /// <summary>
        /// Ensures that the <paramref name="code"/> is a valid error code (400-599)
        /// </summary>
        /// <param name="code">The error code to validate</param>
        /// <returns>The <paramref name="code"/></returns>
        public static int IsValidErrorCode(int code)
        {
            if (code < 400 || code > 599) throw new ArgumentOutOfRangeException(nameof(code), $@"Error code is not between 400 and 599: {code}.");
            return code;
        }

        /// <summary>
        /// Ensures that the <paramref name="code"/> is a valid client-side error code (400-499)
        /// </summary>
        /// <param name="code">The error code to validate</param>
        /// <returns>The <paramref name="code"/></returns>
        public static int IsValidClientErrorCode(int code)
        {
            if (code < 400 || code > 499) throw new ArgumentOutOfRangeException(nameof(code), $@"Client-side error code is not between 400 and 499: {code}.");
            return code;
        }

        /// <summary>
        /// Ensures that the <paramref name="code"/> is a valid server-side error code (500-599)
        /// </summary>
        /// <param name="code">The error code to validate</param>
        /// <returns>The <paramref name="code"/></returns>
        public static int IsValidServerErrorCode(int code)
        {
            if (code < 500 || code > 599) throw new ArgumentOutOfRangeException(nameof(code), $@"Server-side error code is not between 500 and 599: {code}.");
            return code;
        }
    }
}
