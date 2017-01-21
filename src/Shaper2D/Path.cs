﻿// <copyright file="Path.cs" company="Scott Williams">
// Copyright (c) Scott Williams and contributors.
// Licensed under the Apache License, Version 2.0.
// </copyright>

namespace Shaper2D
{
    using System.Collections.Immutable;
    using System.Numerics;

    /// <summary>
    /// A aggregate of <see cref="ILineSegment"/>s making a single logical path
    /// </summary>
    /// <seealso cref="IPath" />
    public class Path : IPath
    {
        /// <summary>
        /// The inner path.
        /// </summary>
        private readonly InternalPath innerPath;

        /// <summary>
        /// Initializes a new instance of the <see cref="Path"/> class.
        /// </summary>
        /// <param name="segment">The segment.</param>
        public Path(params ILineSegment[] segment)
        {
            this.innerPath = new InternalPath(segment, false);
            this.LineSegments = ImmutableArray.Create(segment);
        }

        /// <summary>
        /// Gets the line segments.
        /// </summary>
        /// <value>
        /// The line segments.
        /// </value>
        public ImmutableArray<ILineSegment> LineSegments { get; }

        /// <inheritdoc />
        public Rectangle Bounds => this.innerPath.Bounds;

        /// <inheritdoc />
        public float Length => this.innerPath.Length;

        /// <inheritdoc />
        public ImmutableArray<Point> Flatten()
        {
            return this.innerPath.Points;
        }

        /// <inheritdoc />
        public PointInfo Distance(Point point)
        {
            return this.innerPath.DistanceFromPath(point);
        }

        /// <summary>
        /// Transforms the rectangle using specified matrix.
        /// </summary>
        /// <param name="matrix">The matrix.</param>
        /// <returns>
        /// A new path with the matrix applied to it.
        /// </returns>
        public IPath Transform(Matrix3x2 matrix)
        {
            var segments = new ILineSegment[this.LineSegments.Length];
            var i = 0;
            foreach (var s in this.LineSegments)
            {
                segments[i++] = s.Transform(matrix);
            }

            return new Path(segments);
        }
    }
}