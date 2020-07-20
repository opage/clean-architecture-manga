// <copyright file="AccountId.cs" company="Ivan Paulovich">
// Copyright © Ivan Paulovich. All rights reserved.
// </copyright>

namespace Domain.Accounts.ValueObjects
{
    using System;

    /// <summary>
    ///     AccountId
    ///     <see href="https://github.com/ivanpaulovich/clean-architecture-manga/wiki/Domain-Driven-Design-Patterns#entity">
    ///         Entity
    ///         Design Pattern
    ///     </see>
    ///     .
    /// </summary>
    public readonly struct AccountId : IEquatable<AccountId>
    {
        public Guid Id { get; }

        public AccountId(Guid id) =>
            (this.Id) = (id);

        public override bool Equals(object? obj) =>
            obj is AccountId o && this.Equals(o);

        public bool Equals(AccountId other) => this.Id == other.Id;

        public override int GetHashCode() =>
            HashCode.Combine(this.Id);

        public static bool operator ==(AccountId left, AccountId right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(AccountId left, AccountId right)
        {
            return !(left == right);
        }

        public static AccountId? Create(Notification notification, Guid id)
        {
            if (id != Guid.Empty)
            {
                return new AccountId(id);
            }

            notification.Add("AccountId", "AccountId is required.");
            return null;
        }
    }
}
