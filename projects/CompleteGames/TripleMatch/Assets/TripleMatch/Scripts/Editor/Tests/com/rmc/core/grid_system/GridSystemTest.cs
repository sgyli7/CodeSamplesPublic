/**
 * Copyright (C) 2005-2015 by Rivello Multimedia Consulting (RMC).                    
 * code [at] RivelloMultimediaConsulting [dot] com                                                  
 *                                                                      
 * Permission is hereby granted, free of charge, to any person obtaining
 * a copy of this software and associated documentation files (the      
 * "Software"), to deal in the Software without restriction, including  
 * without limitation the rights to use, copy, modify, merge, publish,  
 * distribute, sublicense, and#or sell copies of the Software, and to   
 * permit persons to whom the Software is furnished to do so, subject to
 * the following conditions:                                            
 *                                                                      
 * The above copyright notice and this permission notice shall be       
 * included in all copies or substantial portions of the Software.      
 *                                                                      
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,      
 * EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF   
 * MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT.
 * IN NO EVENT SHALL THE AUTHORS BE LIABLE FOR ANY CLAIM, DAMAGES OR    
 * OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE,
 * ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR
 * OTHER DEALINGS IN THE SOFTWARE.                                      
 */
// Marks the right margin of code *******************************************************************


//--------------------------------------
//  Imports
//--------------------------------------
using NUnit.Framework;
using System;
using System.Threading;

//--------------------------------------
//  Namespace
//--------------------------------------
using UnityEngine;
using com.rmc.projects.triple_match.mvc.model.data.vo;
using com.rmc.projects.triple_match;


namespace com.rmc.core.grid_system
{
	
	//--------------------------------------
	//  Namespace Properties
	//--------------------------------------
	
	//--------------------------------------
	//  Class Attributes
	//--------------------------------------
	
	//--------------------------------------
	//  Class
	//--------------------------------------
	[TestFixture]
	public class GridSystemTest
	{
		

		//--------------------------------------
		//  Setup
		//--------------------------------------
		
		//	PROPERTIES TO REUSE ACROSS TESTS
		private GridSystem<GemVO> _gridSystem;

		//	CALLED BEFORE EVERY 'TEST' METHOD IN THIS FIXTURE
		[SetUp] 
		public void SetUp()
		{
			_gridSystem = new GridSystem<GemVO>
				(
					TripleMatchConstants.MAX_ROWS, 
					TripleMatchConstants.MAX_COLUMNS,
					TripleMatchConstants.MIN_MATCHES_PER_HORIZONTAL_AXIS_FOR_REWARD,
					TripleMatchConstants.MIN_MATCHES_PER_VERTICAL_AXIS_FOR_REWARD,
					TripleMatchConstants.MAX_GEM_TYPE_INDEX
				);
			
			
		}
		
		
		//	CALLED AFTER EVERY 'TEST' METHOD IN THIS FIXTURE
		[TearDown] 
		public void TearDown()
		{
			_gridSystem = null;
		}


		//--------------------------------------
		//  SampleTests
		//--------------------------------------
		[Test]
		public void InstantiationTest ()
		{

			Assert.NotNull (_gridSystem);
		}

		[Test]
		public void GameResetTest ()
		{
			_gridSystem.Reset(Frequency.Sometimes);
			int expectedValue = TripleMatchConstants.MAX_ROWS * TripleMatchConstants.MAX_COLUMNS;
			int actualValue = _gridSystem.GridSpotVOList().Count;
			Assert.AreEqual (expectedValue, actualValue);
		}

		[Test]
		public void FindMatchesAlwaysWithSuccessTest ()
		{
			_gridSystem.Reset(Frequency.Always);

			//	REPEATING X TIMES IS A GOOD TEST FOR FREQUENCY
			for (var i=0; i < 10; i++)
			{
				int expectedValue = 0; //we expect one or more matches
				int actualValue = _gridSystem.GetMatches().Count;
				Assert.Greater (actualValue, expectedValue);
			}
		}

		
		//--------------------------------------
		//  More Tests
		//--------------------------------------
		/*
		[Test]
		public void ExceptionTest ()
		{
			throw new Exception ("Exception throwing test");
		}
		
		[Test]
		[Ignore ("Ignored test")]
		public void IgnoredTest ()
		{
			throw new Exception ("Ignored this test");
		}
		
		[Test]
		[MaxTime (100)]
		public void SlowTest ()
		{
			Thread.Sleep (200);
		}
		
		[Test]
		public void FailingTest ()
		{
			Assert.Fail ();
		}
		
		[Test]
		public void InconclusiveTest ()
		{
			Assert.Inconclusive();
		}
		
		[Test]
		public void PassingTest ()
		{
			Assert.Pass ();
		}
		
		[Test]
		public void ParameterizedTest ([Values (1, 2, 3)] int a)
		{
			Assert.Pass ();
		}
		
		[Test]
		public void RangeTest ( [Range (1, 10, 3)] int x )
		{
			Assert.Pass ();
		}
		
		[Test]
		[Culture ("pl-PL")]
		public void CultureSpecificTest ()
		{
		}
		
		[Test]
		[ExpectedException (typeof (ArgumentException), ExpectedMessage = "expected message")]
		public void ExpectedExceptionTest ()
		{
			throw new ArgumentException ("expected message");
		}
		
		[Datapoint]
		public double zero = 0;
		[Datapoint]
		public double positive = 1;
		[Datapoint]
		public double negative = -1;
		[Datapoint]
		public double max = double.MaxValue;
		[Datapoint]
		public double infinity = double.PositiveInfinity;
		
		[Theory]
		public void SquareRootDefinition ( double num )
		{
			Assume.That (num >= 0.0 && num < double.MaxValue);
			
			var sqrt = Math.Sqrt (num);
			
			Assert.That (sqrt >= 0.0);
			Assert.That (sqrt * sqrt, Is.EqualTo (num).Within (0.000001));
		}
		
		*/
		//--------------------------------------
		//  Events
		//--------------------------------------
		
		
		
	}
}
