using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

using EPiServer.Web;

using UnidecodeSharpFork;

namespace EPi.UrlTransliterator {
	internal class TransliteratingUrlSegmentGenerator : IUrlSegmentGenerator {
		private static readonly Regex RegexInvalidSegmentNames = new Regex("^COM[0-9]([/\\.]|$)|^LPT[0-9]([/\\.]|$)|^PRN([/\\.]|$)|^CLOCK\\$([/\\.]|$)|^AUX([/\\.]|$)|^NUL([/\\.]|$)|^CON([/\\.]|$)", RegexOptions.IgnoreCase | RegexOptions.Compiled);
		internal const string InvalidSegmentNames = "^COM[0-9]([/\\.]|$)|^LPT[0-9]([/\\.]|$)|^PRN([/\\.]|$)|^CLOCK\\$([/\\.]|$)|^AUX([/\\.]|$)|^NUL([/\\.]|$)|^CON([/\\.]|$)";
		private readonly Regex defaultRegexFindInvalidUrlChars;
		private readonly Func<string, MatchCollection> defaultFindInvalidUrlMethod;
		private readonly Regex defaultRegexValidUrlChars;
		private readonly UrlSegmentOptions defaultOptions;
		public TransliteratingUrlSegmentGenerator(UrlSegmentOptions urlSegmentOptions) {
			urlSegmentOptions = urlSegmentOptions ?? new UrlSegmentOptions();
			defaultRegexValidUrlChars = new Regex($"^[{urlSegmentOptions.ValidUrlCharacters}]+$", RegexOptions.Compiled);
			defaultRegexFindInvalidUrlChars = new Regex($"[^{urlSegmentOptions.ValidUrlCharacters}]{{1}}", RegexOptions.Compiled);
			defaultFindInvalidUrlMethod = s => defaultRegexFindInvalidUrlChars.Matches(s);
			defaultOptions = urlSegmentOptions;
		}
		public bool IsValid(string segment, UrlSegmentOptions options) {
			return options == null ? defaultRegexValidUrlChars.IsMatch(segment) : Regex.IsMatch(segment, $"^[{options.ValidUrlCharacters}]+$");
		}
		public string Create(string proposedSegment, UrlSegmentOptions options) {
			var segmentOption = options ?? defaultOptions;
			var charMap = segmentOption.CharacterMap;
			var invalidCharRegex = options != null ? (s => Regex.Matches(s, $"[^{options.ValidUrlCharacters}]{{1}}")) : defaultFindInvalidUrlMethod;
			var cleanedSegment = ReplaceIllegalNames(ReplaceIllegalChars(Transliterate(proposedSegment), invalidCharRegex, charMap));
			while(cleanedSegment.Contains("--")) {
				cleanedSegment = cleanedSegment.Replace("--", "-");
			}
			while(cleanedSegment.EndsWith(".") || cleanedSegment.EndsWith("-")) {
				cleanedSegment = cleanedSegment.Substring(0, cleanedSegment.Length - 1);
			}
			if(segmentOption.UseLowercase) {
				return cleanedSegment.ToLowerInvariant();
			}
			return cleanedSegment;
		}
		private static string Transliterate(string proposedSegment) {
			return proposedSegment.Unidecode();
		}
		internal static string ReplaceIllegalNames(string inputString) {
			if(RegexInvalidSegmentNames.IsMatch(inputString)) {
				return $"{inputString}_";
			}
			return inputString;
		}
		private static string ReplaceIllegalChars(string inputString, Func<string, MatchCollection> invalidCharRegex, IDictionary<char, char> charMap) {
			var stringBuilder = new StringBuilder(inputString);
			var matchCollection = invalidCharRegex(inputString);
			for(var index = 0; index < matchCollection.Count; ++index) {
				char ch;
				if(charMap.TryGetValue(stringBuilder[matchCollection[index].Index], out ch)) {
					stringBuilder[matchCollection[index].Index] = ch;
				} else {
					stringBuilder[matchCollection[index].Index] = '?';
				}
			}
			stringBuilder.Replace("?", string.Empty);
			return stringBuilder.ToString();
		}
	}
}