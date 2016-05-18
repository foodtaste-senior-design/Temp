﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Kinect = Windows.Kinect;
using UnityEngine.UI;

public class BodySourceView : MonoBehaviour 
{
	public Material BoneMaterial;
	public GameObject BodySourceManager;
	
	private Dictionary<ulong, GameObject> _Bodies = new Dictionary<ulong, GameObject>();
	private BodySourceManager _BodyManager;
	
	public Text coordinates;

	// Head coordinates
	static float x;
	static float y;

	// Hip coordinates
	static float hipLeftX;
	static float hipLeftY;
	static float hipRightX;
	static float hipRightY;

	// Knee coordinates
	static float kneeLeftX;
	static float kneeLeftY;
	static float kneeRightX;
	static float kneeRightY;

	public static bool bodyTracked;
	
	private Dictionary<Kinect.JointType, Kinect.JointType> _BoneMap = new Dictionary<Kinect.JointType, Kinect.JointType>()
	{
		{ Kinect.JointType.FootLeft, Kinect.JointType.AnkleLeft },
		{ Kinect.JointType.AnkleLeft, Kinect.JointType.KneeLeft },
		{ Kinect.JointType.KneeLeft, Kinect.JointType.HipLeft },
		{ Kinect.JointType.HipLeft, Kinect.JointType.SpineBase },
		
		{ Kinect.JointType.FootRight, Kinect.JointType.AnkleRight },
		{ Kinect.JointType.AnkleRight, Kinect.JointType.KneeRight },
		{ Kinect.JointType.KneeRight, Kinect.JointType.HipRight },
		{ Kinect.JointType.HipRight, Kinect.JointType.SpineBase },
		
		{ Kinect.JointType.HandTipLeft, Kinect.JointType.HandLeft },
		{ Kinect.JointType.ThumbLeft, Kinect.JointType.HandLeft },
		{ Kinect.JointType.HandLeft, Kinect.JointType.WristLeft },
		{ Kinect.JointType.WristLeft, Kinect.JointType.ElbowLeft },
		{ Kinect.JointType.ElbowLeft, Kinect.JointType.ShoulderLeft },
		{ Kinect.JointType.ShoulderLeft, Kinect.JointType.SpineShoulder },
		
		{ Kinect.JointType.HandTipRight, Kinect.JointType.HandRight },
		{ Kinect.JointType.ThumbRight, Kinect.JointType.HandRight },
		{ Kinect.JointType.HandRight, Kinect.JointType.WristRight },
		{ Kinect.JointType.WristRight, Kinect.JointType.ElbowRight },
		{ Kinect.JointType.ElbowRight, Kinect.JointType.ShoulderRight },
		{ Kinect.JointType.ShoulderRight, Kinect.JointType.SpineShoulder },
		
		{ Kinect.JointType.SpineBase, Kinect.JointType.SpineMid },
		{ Kinect.JointType.SpineMid, Kinect.JointType.SpineShoulder },
		{ Kinect.JointType.SpineShoulder, Kinect.JointType.Neck },
		{ Kinect.JointType.Neck, Kinect.JointType.Head },
	};
	
	void Update () 
	{
		if (BodySourceManager == null)
		{
			return;
		}
		
		_BodyManager = BodySourceManager.GetComponent<BodySourceManager>();
		if (_BodyManager == null)
		{
			return;
		}
		
		Kinect.Body[] data = _BodyManager.GetData();
		if (data == null)
		{
			return;
		}
		
		List<ulong> trackedIds = new List<ulong>();
		foreach(var body in data)
		{
			if (body == null)
			{
				continue;
			}
			
			if(body.IsTracked)
			{
				trackedIds.Add (body.TrackingId);
			}
		}
		
		List<ulong> knownIds = new List<ulong>(_Bodies.Keys);
		
		// First delete untracked bodies
		foreach(ulong trackingId in knownIds)
		{
			if(!trackedIds.Contains(trackingId))
			{
				Destroy(_Bodies[trackingId]);
				_Bodies.Remove(trackingId);
			}
		}
		
		bodyTracked = false;
		
		foreach(var body in data)
		{
			if (body == null)
			{
				continue;
			}
			
			if (bodyTracked){
				continue;
			}
			
			if(body.IsTracked)
			{
				if(!_Bodies.ContainsKey(body.TrackingId))
				{
					// Draws stick figure of body to screen
					//_Bodies[body.TrackingId] = CreateBodyObject(body.TrackingId);
				}

				//RefreshBodyObject(body, _Bodies[body.TrackingId]);
				
				// head tracking code
				Kinect.Joint headJoint = body.Joints[Kinect.JointType.Head];

				Kinect.Joint hipLeftJoint = body.Joints [Kinect.JointType.HipLeft];
				Kinect.Joint hipRightJoint = body.Joints [Kinect.JointType.HipRight];

				Kinect.Joint kneeLeftJoint = body.Joints [Kinect.JointType.KneeLeft];
				Kinect.Joint kneeRightJoint = body.Joints [Kinect.JointType.KneeRight];

				if (headJoint.TrackingState == Kinect.TrackingState.Tracked)
				{
					Kinect.KinectSensor sensor = _BodyManager.getSensor();
					Kinect.DepthSpacePoint dsp = sensor.CoordinateMapper.MapCameraPointToDepthSpace(headJoint.Position);

					Kinect.DepthSpacePoint hipLeftDSP = sensor.CoordinateMapper.MapCameraPointToDepthSpace(hipLeftJoint.Position);
					Kinect.DepthSpacePoint hipRightDSP = sensor.CoordinateMapper.MapCameraPointToDepthSpace(hipRightJoint.Position);

					Kinect.DepthSpacePoint kneeLeftDSP = sensor.CoordinateMapper.MapCameraPointToDepthSpace(kneeLeftJoint.Position);
					Kinect.DepthSpacePoint kneeRightDSP = sensor.CoordinateMapper.MapCameraPointToDepthSpace(kneeRightJoint.Position);

					x = dsp.X;
					y = dsp.Y;

					hipLeftX = hipLeftDSP.X;
					hipLeftY = hipLeftDSP.Y;
					hipRightX = hipRightDSP.X;
					hipRightY = hipRightDSP.Y;

					kneeLeftX = kneeLeftDSP.X;
					kneeLeftY = kneeLeftDSP.Y;
					kneeRightX = kneeRightDSP.X;
					kneeRightY = kneeRightDSP.Y;

					bodyTracked = true;

					// Debug Squatting
/*					float squatLeft = Mathf.Abs (hipLeftY - kneeLeftY);
					float squatRight = Mathf.Abs (hipRightY - kneeRightY);

					if (squatLeft < 25 && squatRight < 25) {
						Debug.Log ("Squat: " + squatLeft + ", " + squatRight);
					} else {
						Debug.Log ("NOT SQUAT: " + squatLeft + ", " + squatRight);
					}
*?
/*					// Print coordinates
					Debug.Log ("Left Hip: " + hipLeftX + ", " + hipLeftY);
					Debug.Log ("Right Hip: " + hipRightX + ", " + hipRightY);
					Debug.Log ("Left Knee: " + kneeLeftX + ", " + kneeLeftY);
					Debug.Log ("Right Knee: " + kneeRightX + ", " + kneeRightY);
*/

				}
			}
		}
	}
	
	private GameObject CreateBodyObject(ulong id)
	{
		GameObject body = new GameObject("Body:" + id);
		
		for (Kinect.JointType jt = Kinect.JointType.SpineBase; jt <= Kinect.JointType.ThumbRight; jt++)
		{
			GameObject jointObj = GameObject.CreatePrimitive(PrimitiveType.Cube);
			
			LineRenderer lr = jointObj.AddComponent<LineRenderer>();
			lr.SetVertexCount(2);
			lr.material = BoneMaterial;
			lr.SetWidth(0.05f, 0.05f);
			
			jointObj.transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
			jointObj.name = jt.ToString();
			jointObj.transform.parent = body.transform;
		}
		
		return body;
	}
	
	private void RefreshBodyObject(Kinect.Body body, GameObject bodyObject)
	{
		for (Kinect.JointType jt = Kinect.JointType.SpineBase; jt <= Kinect.JointType.ThumbRight; jt++)
		{
			Kinect.Joint sourceJoint = body.Joints[jt];
			Kinect.Joint? targetJoint = null;
			
			if(_BoneMap.ContainsKey(jt))
			{
				targetJoint = body.Joints[_BoneMap[jt]];
			}
			
			Transform jointObj = bodyObject.transform.FindChild(jt.ToString());
			jointObj.localPosition = GetVector3FromJoint(sourceJoint);
			
			LineRenderer lr = jointObj.GetComponent<LineRenderer>();
			if(targetJoint.HasValue)
			{
				lr.SetPosition(0, jointObj.localPosition);
				lr.SetPosition(1, GetVector3FromJoint(targetJoint.Value));
				lr.SetColors(GetColorForState (sourceJoint.TrackingState), GetColorForState(targetJoint.Value.TrackingState));
			}
			else
			{
				lr.enabled = false;
			}
		}
	}
	
	private static Color GetColorForState(Kinect.TrackingState state)
	{
		switch (state)
		{
		case Kinect.TrackingState.Tracked:
			return Color.green;
			
		case Kinect.TrackingState.Inferred:
			return Color.red;
			
		default:
			return Color.black;
		}
	}
	
	private static Vector3 GetVector3FromJoint(Kinect.Joint joint)
	{
		return new Vector3(joint.Position.X * 10, joint.Position.Y * 10, joint.Position.Z * 10);
	}

	// Returns x value
	public static float getX(){
		return x;
	}

	public static float getY(){
		return y;
	}

	// Return hip coordinates
	public static float[] getHips(){
		float[] hips = new float[4]{ hipLeftX, hipLeftY, hipRightX, hipRightY };
		return hips;
	}

	// return knee coordinates
	public static float[] getKnees(){
		float[] knees = new float[4]{ kneeLeftX, kneeLeftY, kneeRightX, kneeRightY };
		return knees;
	}

	public static bool isBodyTracked(){
		return bodyTracked;
	}
}
