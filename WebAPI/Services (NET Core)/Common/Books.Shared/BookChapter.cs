using System;

namespace Books.Shared;

public record BookChapter(Guid Id, int Number, string Title, int PageCount);
