// Copyright (c) Six Labors and contributors.
// Licensed under the Apache License, Version 2.0.
using System;
using SixLabors.Primitives;

namespace SixLabors.Shapes
{
    /// <summary>
    /// An array interface for writing points to.
    /// </summary>
    public interface IPointFWriter
    {
        /// <summary>
        /// Gets the length.
        /// </summary>
        int Length
        {
            get;
        }

        /// <summary>
        /// Sets a point at given index.
        /// </summary>
        /// <param name="index">the index.</param>
        PointF this[int index]
        {
            set;
        }
    }

    /// <summary>
    /// A <see cref="PointF"/> writer that writes to a float array buffer.
    /// </summary>
    public struct FloatArrayPointFWriter : IPointFWriter
    {
        private float[] buffer;

        /// <summary>
        /// Initializes a new instance of the <see cref="FloatArrayPointFWriter"/> struct.
        /// </summary>
        /// <param name="buffer">The buffer.</param>
        public FloatArrayPointFWriter(float[] buffer)
        {
            this.buffer = buffer;
        }

        /// <inheritdoc/>
        public int Length => this.buffer.Length;

        /// <inheritdoc/>
        public PointF this[int index]
        {
            set
            {
                this.buffer[index] = value.X;
            }
        }
    }

    /// <summary>
    /// A <see cref="PointF"/> writer that writes to a <see cref="PointF"/> array buffer.
    /// </summary>
    public struct PointFArrayPointWriter : IPointFWriter
    {
        private PointF[] buffer;

        /// <summary>
        /// Initializes a new instance of the <see cref="PointFArrayPointWriter"/> struct.
        /// /// </summary>
        /// <param name="buffer">The buffer.</param>
        public PointFArrayPointWriter(PointF[] buffer)
        {
            this.buffer = buffer;
        }

        /// <inheritdoc/>
        public int Length => this.buffer.Length;

        /// <inheritdoc/>
        public PointF this[int index]
        {
            set
            {
                this.buffer[index] = value;
            }
        }
    }
}
