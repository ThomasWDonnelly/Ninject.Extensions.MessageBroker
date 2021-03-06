#region License

// 
// Author: Nate Kohari <nate@enkari.com>
// Copyright (c) 2007-2010, Enkari, Ltd.
// 
// Dual-licensed under the Apache License, Version 2.0, and the Microsoft Public License (Ms-PL).
// See the file LICENSE.txt for details.
// 

#endregion

#region Using Directives

using System.Reflection;
using System.Text;
using Ninject.Planning.Directives;

#endregion

namespace Ninject.Extensions.MessageBroker.Planning.Directives
{
    /// <summary>
    /// A directive that describes a message publication.
    /// </summary>
    public class PublicationDirective : IDirective
    {
        #region Fields

        private readonly string _channel;
        private readonly EventInfo _evt;

        #endregion

        #region Properties

        /// <summary>
        /// Gets the name of the channel that is to be published to.
        /// </summary>
        public string Channel
        {
            get { return _channel; }
        }


        /// <summary>
        /// Gets the event that will be published to the channel.
        /// </summary>
        public EventInfo Event
        {
            get { return _evt; }
        }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="PublicationDirective"/> class.
        /// </summary>
        /// <param name="channel">The name of the channel that is to be published to.</param>
        /// <param name="evt">The event that will be published to the channel.</param>
        public PublicationDirective( string channel, EventInfo evt )
        {
            Ensure.ArgumentNotNullOrEmpty( channel, "channel" );
            Ensure.ArgumentNotNull( evt, "evt" );

            _channel = channel;
            _evt = evt;
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Builds the value that uniquely identifies the directive. This is called the first time
        /// the key is accessed, and then cached in the directive.
        /// </summary>
        /// <returns>The directive's unique key.</returns>
        /// <remarks>
        /// This exists because most directives' keys are based on reading member information,
        /// especially parameters. Since it's a relatively expensive procedure, it shouldn't be
        /// done each time the key is accessed.
        /// </remarks>
        protected object BuildKey()
        {
            var sb = new StringBuilder();

            sb.Append( _channel );
            sb.Append( _evt.Name );

            return sb.ToString();
        }

        #endregion
    }
}