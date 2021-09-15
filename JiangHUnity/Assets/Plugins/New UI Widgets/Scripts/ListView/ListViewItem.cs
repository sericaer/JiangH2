﻿// <auto-generated/>
// Auto-generated added to suppress names errors.

namespace UIWidgets
{
	using System;
	using System.Collections.Generic;
	using UIWidgets.Extensions;
	using UIWidgets.Styles;
	using UnityEngine;
	using UnityEngine.Events;
	using UnityEngine.EventSystems;
	using UnityEngine.UI;

	/// <summary>
	/// ListViewItem.
	/// Item for ListViewBase.
	/// </summary>
	[RequireComponent(typeof(Image))]
	public class ListViewItem : UIBehaviour,
		IPointerClickHandler, IPointerDownHandler, IPointerUpHandler,
		IPointerEnterHandler, IPointerExitHandler,
		ISubmitHandler, ICancelHandler,
		ISelectHandler, IDeselectHandler,
		IMoveHandler, IStylable, IMovableToCache, IUpgradeable
	{
		/// <summary>
		/// Toggle item selection on click.
		/// </summary>
		[SerializeField]
		[Tooltip("Select / Deselect item on pointer click.")]
		public bool ToggleOnClick = true;

		/// <summary>
		/// Toggle item selection on submit.
		/// </summary>
		[SerializeField]
		[Tooltip("Select / Deselect item on keyboard or gamepad submit key.")]
		public bool ToggleOnSubmit = true;

		/// <summary>
		/// The index of item in ListView.
		/// </summary>
		[HideInInspector]
		public int Index = -1;

		/// <summary>
		/// What to do when the event system send a pointer click event.
		/// </summary>
		[Obsolete("Replaced with onClickItem.")]
		public UnityEvent onClick = new UnityEvent();

		/// <summary>
		/// What to do when the event system send a pointer click event.
		/// </summary>
		public ListViewItemSelect onClickItem = new ListViewItemSelect();

		/// <summary>
		/// What to do when the event system send a pointer down event.
		/// </summary>
		public PointerUnityEvent onPointerDown = new PointerUnityEvent();

		/// <summary>
		/// What to do when the event system send a pointer up event.
		/// </summary>
		public PointerUnityEvent onPointerUp = new PointerUnityEvent();

		/// <summary>
		/// What to do when the event system send a submit event.
		/// </summary>
		public ListViewItemSelect onSubmit = new ListViewItemSelect();

		/// <summary>
		/// What to do when the event system send a cancel event.
		/// </summary>
		public ListViewItemSelect onCancel = new ListViewItemSelect();

		/// <summary>
		/// What to do when the event system send a select event.
		/// </summary>
		public ListViewItemSelect onSelect = new ListViewItemSelect();

		/// <summary>
		/// What to do when the event system send a deselect event.
		/// </summary>
		public ListViewItemSelect onDeselect = new ListViewItemSelect();

		/// <summary>
		/// What to do when the event system send a move event.
		/// </summary>
		public ListViewItemMove onMove = new ListViewItemMove();

		/// <summary>
		/// What to do when the event system send a pointer click event.
		/// </summary>
		public PointerUnityEvent onPointerClick = new PointerUnityEvent();

		/// <summary>
		/// What to do when the event system send a pointer enter event.
		/// </summary>
		public PointerUnityEvent onPointerEnter = new PointerUnityEvent();

		/// <summary>
		/// What to do when the event system send a pointer enter event.
		/// </summary>
		public ListViewItemSelect onPointerEnterItem = new ListViewItemSelect();

		/// <summary>
		/// What to do when the event system send a pointer exit event.
		/// </summary>
		public PointerUnityEvent onPointerExit = new PointerUnityEvent();

		/// <summary>
		/// What to do when the event system send a pointer exit event.
		/// </summary>
		public ListViewItemSelect onPointerExitItem = new ListViewItemSelect();

		/// <summary>
		/// OnResize event.
		/// </summary>
		public ListViewItemResize onResize = new ListViewItemResize();

		/// <summary>
		/// OnDoubleClick event.
		/// </summary>
		public ListViewItemClick onDoubleClick = new ListViewItemClick();

		/// <summary>
		/// Parent ListView.
		/// </summary>
		[HideInInspector]
		public ListViewBase Owner;

		Image background;

		/// <summary>
		/// Is dragged?
		/// </summary>
		[NonSerialized]
		public bool IsDragged;

		/// <summary>
		/// The background.
		/// </summary>
		public Image Background
		{
			get
			{
				if (background == null)
				{
					background = GetComponent<Image>();
				}

				return background;
			}
		}

		RectTransform rectTransform;

		/// <summary>
		/// Gets the RectTransform.
		/// </summary>
		/// <value>The RectTransform.</value>
		public RectTransform RectTransform
		{
			get
			{
				if (rectTransform == null)
				{
					rectTransform = transform as RectTransform;
				}

				return rectTransform;
			}
		}

		/// <summary>
		/// Selectable objects.
		/// </summary>
		[HideInInspector]
		[SerializeField]
		protected List<GameObject> SelectableObjects = new List<GameObject>();

		/// <summary>
		/// Selectable targets.
		/// </summary>
		protected List<ISelectHandler> SelectableTargets = new List<ISelectHandler>();

		/// <summary>
		/// Find selectable GameObjects.
		/// </summary>
		public virtual void FindSelectableObjects()
		{
			SelectableObjects.Clear();
			SelectableTargets.Clear();
			Compatibility.GetComponentsInChildren(this, true, SelectableTargets);

			for (int i = 0; i < SelectableTargets.Count; i++)
			{
				SelectableObjects.Add((SelectableTargets[i] as Component).gameObject);
			}
		}

		/// <summary>
		/// Get index of the specified selectable GameObject.
		/// </summary>
		/// <param name="go">Selectable GameObject</param>
		/// <returns>Index of the specified selectable GameObject.</returns>
		public virtual int GetSelectableIndex(GameObject go)
		{
			return SelectableObjects.IndexOf(go);
		}

		/// <summary>
		/// Get selectable GameObject by specified index.
		/// </summary>
		/// <param name="index">Index.</param>
		/// <returns>Selectable GameObject.</returns>
		public virtual GameObject GetSelectableObject(int index)
		{
			if ((index < 0) || (index >= SelectableObjects.Count))
			{
				return null;
			}

			return SelectableObjects[index];
		}

		#region GraphicsColoring

		/// <summary>
		/// Is colors setted at least once?
		/// </summary>
		protected bool GraphicsColorSetted = false;

		/// <summary>
		/// Foreground graphics for coloring.
		/// </summary>
		[SerializeField]
		protected Graphic[] Foreground = Compatibility.EmptyArray<Graphic>();

		/// <summary>
		/// Gets foreground graphics for coloring.
		/// </summary>
		public virtual Graphic[] GraphicsForeground
		{
			get
			{
				GraphicsForegroundInit();

				return Foreground;
			}
		}

		/// <summary>
		/// Background graphics for coloring.
		/// </summary>
		[SerializeField]
		protected Graphic[] graphicsBackground = Compatibility.EmptyArray<Graphic>();

		/// <summary>
		/// Background graphics for coloring.
		/// </summary>
		public virtual Graphic[] GraphicsBackground
		{
			get
			{
				GraphicsBackgroundInit();

				var style_table = (Owner != null) && Owner.StyleTable;
				return style_table ? cellsGraphicsBackground : graphicsBackground;
			}
		}

		/// <summary>
		/// CellsBackground version.
		/// </summary>
		[SerializeField]
		[HideInInspector]
		protected int CellsBackgroundVersion = 0;

		/// <summary>
		/// Cells graphics background.
		/// </summary>
		[SerializeField]
		protected Graphic[] cellsGraphicsBackground = Compatibility.EmptyArray<Graphic>();

		/// <summary>
		/// Process locale changes.
		/// </summary>
		public virtual void LocaleChanged()
		{
		}

		/// <summary>
		/// Reset graphics colors.
		/// </summary>
		/// <param name="graphic">Graphic.</param>
		protected virtual void GraphicsReset(Graphic graphic)
		{
			if (graphic != null)
			{
				graphic.color = Color.white;
			}
		}

		/// <summary>
		/// Set the specified color for the graphics.
		/// </summary>
		/// <param name="graphics">Graphics.</param>
		/// <param name="color">New color.</param>
		/// <param name="fadeDuration">Time for fade the original color to the new one.</param>
		protected void GraphicsSet(Graphic[] graphics, Color color, float fadeDuration)
		{
			if (graphics == null)
			{
				return;
			}

			// reset default color to white, otherwise it will look darker than specified color,
			// because actual color = graphic.color * graphic.CrossFadeColor
			if (!GraphicsColorSetted)
			{
				GraphicsReset(graphics);
			}

			var duration = GraphicsColorSetted ? fadeDuration : 0f;
			foreach (var g in graphics)
			{
				if (g != null)
				{
					g.CrossFadeColor(color, duration, true, true);
				}
			}
		}

		/// <summary>
		/// Reset graphics colors.
		/// </summary>
		/// <param name="graphics">Graphics.</param>
		protected void GraphicsReset(Graphic[] graphics)
		{
			if (graphics == null)
			{
				return;
			}

			graphics.ForEach(GraphicsReset);
		}

		/// <summary>
		/// Set graphics colors.
		/// </summary>
		/// <param name="foregroundColor">Foreground color.</param>
		/// <param name="backgroundColor">Background color.</param>
		/// <param name="fadeDuration">Fade duration.</param>
		public virtual void GraphicsColoring(Color foregroundColor, Color backgroundColor, float fadeDuration = 0.0f)
		{
			GraphicsSet(GraphicsForeground, foregroundColor, GraphicsColorSetted ? fadeDuration : 0f);
			GraphicsSet(GraphicsBackground, backgroundColor, GraphicsColorSetted ? fadeDuration : 0f);

			GraphicsColorSetted = true;
		}

		/// <summary>
		/// Set the specified color for the graphics (to use in editor mode only).
		/// </summary>
		/// <param name="graphics">Graphics.</param>
		/// <param name="color">New color.</param>
		protected void SetColors(Graphic[] graphics, Color color)
		{
			if (graphics == null)
			{
				return;
			}

			foreach (var g in graphics)
			{
				if (g != null)
				{
					g.color = color;
				}
			}
		}

		/// <summary>
		/// Set colors (to use in editor mode only).
		/// </summary>
		/// <param name="foregroundColor">Foreground color.</param>
		/// <param name="backgroundColor">Background color.</param>
		public virtual void SetColors(Color foregroundColor, Color backgroundColor)
		{
			SetColors(GraphicsForeground, foregroundColor);
			SetColors(GraphicsBackground, backgroundColor);
		}
		#endregion

		/// <summary>
		/// Is need to set localPosition.z to 0?
		/// </summary>
		[SerializeField]
		protected bool LocalPositionZReset;

		/// <summary>
		/// Awake this instance.
		/// </summary>
		protected override void Awake()
		{
			if (LocalPositionZReset && (transform.localPosition.z != 0f))
			{
				var pos = transform.localPosition;
				pos.z = 0f;
				transform.localPosition = pos;
			}
		}

		/// <summary>
		/// Determines whether owner widget is interactable.
		/// </summary>
		/// <returns><c>true</c> if owner widget is interactable; otherwise, <c>false</c>.</returns>
		public virtual bool IsInteractable()
		{
			if (Owner == null)
			{
				return true;
			}

			return Owner.IsInteractable();
		}

		/// <summary>
		/// Process the pointer down event.
		/// </summary>
		/// <param name="eventData">Current event data.</param>
		public virtual void OnPointerDown(PointerEventData eventData)
		{
			if (!IsInteractable())
			{
				return;
			}

			onPointerDown.Invoke(eventData);

			if (AllowItemsEvents())
			{
				Owner.ItemsEvents.PointerDown.Invoke(Index, this, eventData);
			}
		}

		/// <summary>
		/// Process the pointer up event.
		/// </summary>
		/// <param name="eventData">Current event data.</param>
		public virtual void OnPointerUp(PointerEventData eventData)
		{
			if (!IsInteractable())
			{
				return;
			}

			onPointerUp.Invoke(eventData);

			if (AllowItemsEvents())
			{
				Owner.ItemsEvents.PointerUp.Invoke(Index, this, eventData);
			}
		}

		/// <summary>
		/// Process the move event.
		/// </summary>
		/// <param name="eventData">Event data.</param>
		public virtual void OnMove(AxisEventData eventData)
		{
			if (!IsInteractable())
			{
				return;
			}

			onMove.Invoke(eventData, this);

			if (AllowItemsEvents())
			{
				Owner.ItemsEvents.Move.Invoke(Index, this, eventData);
			}
		}

		/// <summary>
		/// Process the submit event.
		/// </summary>
		/// <param name="eventData">Event data.</param>
		public virtual void OnSubmit(BaseEventData eventData)
		{
			if (!IsInteractable())
			{
				return;
			}

			if (ToggleOnSubmit && (Owner != null))
			{
				Owner.ItemToggle(Index);
			}

			onSubmit.Invoke(this);

			if (AllowItemsEvents())
			{
				Owner.ItemsEvents.Submit.Invoke(Index, this, eventData);
			}
		}

		/// <summary>
		/// Process the cancel event.
		/// </summary>
		/// <param name="eventData">Event data.</param>
		public virtual void OnCancel(BaseEventData eventData)
		{
			if (!IsInteractable())
			{
				return;
			}

			onCancel.Invoke(this);

			if (AllowItemsEvents())
			{
				Owner.ItemsEvents.Cancel.Invoke(Index, this, eventData);
			}
		}

		/// <summary>
		/// Process the select event.
		/// </summary>
		/// <param name="eventData">Event data.</param>
		public virtual void OnSelect(BaseEventData eventData)
		{
			if (!IsInteractable())
			{
				return;
			}

			Select();
			onSelect.Invoke(this);

			if (AllowItemsEvents())
			{
				Owner.ItemsEvents.Select.Invoke(Index, this, eventData);
			}
		}

		/// <summary>
		/// Process the deselect event.
		/// </summary>
		/// <param name="eventData">Event data.</param>
		public virtual void OnDeselect(BaseEventData eventData)
		{
			if (!IsInteractable())
			{
				return;
			}

			onDeselect.Invoke(this);

			if (AllowItemsEvents())
			{
				Owner.ItemsEvents.Deselect.Invoke(Index, this, eventData);
			}
		}

		/// <summary>
		/// Process the pointer click event.
		/// </summary>
		/// <param name="eventData">Current event data.</param>
		public virtual void OnPointerClick(PointerEventData eventData)
		{
			if (!IsInteractable())
			{
				return;
			}

			onPointerClick.Invoke(eventData);

			if (AllowItemsEvents())
			{
				Owner.ItemsEvents.PointerClick.Invoke(Index, this, eventData);
			}

			if ((eventData.button == PointerEventData.InputButton.Left) && (eventData.clickCount == 1))
			{
				#pragma warning disable 0618
				onClick.Invoke();
				#pragma warning restore 0618

				if (ToggleOnClick && (Owner != null))
				{
					Owner.ItemToggle(Index);
				}

				Select();

				onClickItem.Invoke(this);

				if (Owner != null)
				{
					Owner.ItemsEvents.FirstClick.Invoke(Index, this, eventData);
				}
			}

			if ((eventData.button == PointerEventData.InputButton.Left) && (eventData.clickCount == 2))
			{
				onDoubleClick.Invoke(Index);
				if (AllowItemsEvents())
				{
					Owner.ItemsEvents.DoubleClick.Invoke(Index, this, eventData);
				}
			}
		}

		/// <summary>
		/// Process the pointer enter event.
		/// </summary>
		/// <param name="eventData">Event data.</param>
		public virtual void OnPointerEnter(PointerEventData eventData)
		{
			if (!IsInteractable())
			{
				return;
			}

			onPointerEnter.Invoke(eventData);
			onPointerEnterItem.Invoke(this);

			if (AllowItemsEvents())
			{
				Owner.ItemsEvents.PointerEnter.Invoke(Index, this, eventData);
			}
		}

		/// <summary>
		/// Process the pointer exit event.
		/// </summary>
		/// <param name="eventData">Event data.</param>
		public virtual void OnPointerExit(PointerEventData eventData)
		{
			if (!IsInteractable())
			{
				return;
			}

			onPointerExit.Invoke(eventData);
			onPointerExitItem.Invoke(this);

			if (AllowItemsEvents())
			{
				Owner.ItemsEvents.PointerExit.Invoke(Index, this, eventData);
			}
		}

		/// <summary>
		/// Select this instance.
		/// </summary>
		public virtual void Select()
		{
			if (!IsInteractable())
			{
				return;
			}

			if (EventSystem.current.alreadySelecting)
			{
				return;
			}

			var ev = new ListViewItemEventData(EventSystem.current)
			{
				NewSelectedObject = gameObject
			};
			EventSystem.current.SetSelectedGameObject(ev.NewSelectedObject, ev);
		}

		Rect oldRect;

		/// <summary>
		/// Implementation of a callback that is sent if an associated RectTransform has it's dimensions changed..
		/// </summary>
		protected override void OnRectTransformDimensionsChange()
		{
			if (oldRect.Equals(RectTransform.rect))
			{
				return;
			}

			oldRect = RectTransform.rect;
			onResize.Invoke(Index, oldRect.size);

			if (AllowItemsEvents())
			{
				Owner.ItemsEvents.Resize.Invoke(Index, this, oldRect.size);
			}
		}

		/// <summary>
		/// Called when item moved to cache, you can use it free used resources.
		/// </summary>
		public virtual void MovedToCache()
		{
		}

		/// <summary>
		/// Called when item in default state.
		/// </summary>
		public virtual void StateDefault()
		{
		}

		/// <summary>
		/// Called when item selected.
		/// </summary>
		public virtual void StateSelected()
		{
		}

		/// <summary>
		/// Called when item highlighted.
		/// </summary>
		public virtual void StateHighlighted()
		{
		}

		/// <summary>
		/// Upgrade this instance.
		/// </summary>
		public virtual void Upgrade()
		{
		}

		/// <summary>
		/// Is item events allowed?
		/// </summary>
		/// <returns>true if has owner and has valid index; otherwise false.</returns>
		protected virtual bool AllowItemsEvents()
		{
			return (Owner != null) && Owner.IsValid(Index);
		}

		/// <summary>
		/// Graphics background version.
		/// </summary>
		[SerializeField]
		[HideInInspector]
		protected byte GraphicsBackgroundVersion = 0;

		/// <summary>
		/// Init graphics background.
		/// </summary>
		protected virtual void GraphicsBackgroundInit()
		{
			if (GraphicsBackgroundVersion == 0)
			{
				graphicsBackground = new Graphic[] { Background };
				GraphicsBackgroundVersion = 1;
			}
		}

		/// <summary>
		/// Graphics foreground version.
		/// </summary>
		[SerializeField]
		[HideInInspector]
		protected byte GraphicsForegroundVersion = 0;

		/// <summary>
		/// Init graphics foreground.
		/// </summary>
		protected virtual void GraphicsForegroundInit()
		{
		}

#if UNITY_EDITOR
		/// <summary>
		/// Validate this instance.
		/// </summary>
		protected override void OnValidate()
		{
			base.OnValidate();

			Upgrade();

			GraphicsBackgroundInit();
			GraphicsForegroundInit();

#if UNITY_2018_3_OR_NEWER
			if (UnityEditor.PrefabUtility.IsPartOfAnyPrefab(this))
#endif
			{
				UnityEditor.PrefabUtility.RecordPrefabInstancePropertyModifications(this);
			}

			if (Compatibility.IsPrefab(this))
			{
				UnityEditor.EditorUtility.SetDirty(this);
			}
		}
#endif

		#region IStylable implementation

		/// <summary>
		/// Reset graphics.
		/// </summary>
		protected virtual void ResetGraphics()
		{
#if UNITY_EDITOR
			var is_playmode = UnityEditor.EditorApplication.isPlaying;
#else
			var is_playmode = true;
#endif

			if (is_playmode)
			{
				GraphicsReset(GraphicsForeground);
				GraphicsReset(GraphicsBackground);
			}
		}

		/// <summary>
		/// Set the style.
		/// </summary>
		/// <param name="styleBackground">Style for the background.</param>
		/// <param name="styleText">Style for the text.</param>
		/// <param name="style">Full style data.</param>
		public virtual void SetStyle(StyleImage styleBackground, StyleText styleText, Style style)
		{
			styleBackground.ApplyTo(Background);

			if ((Owner != null) && (Owner.StyleTable))
			{
				Background.sprite = null;

				if (GraphicsBackground != null)
				{
					GraphicsBackground.ForEach(style.Table.Background.ApplyTo);
				}
			}

			if (GraphicsForeground != null)
			{
				foreach (var gf in GraphicsForeground)
				{
					if (gf != null)
					{
						styleText.ApplyTo(gf.gameObject);
					}
				}
			}

			ResetGraphics();
		}

		/// <inheritdoc/>
		public virtual bool SetStyle(Style style)
		{
			SetStyle(style.Collections.DefaultItemBackground, style.Collections.DefaultItemText, style);

			return true;
		}

		/// <summary>
		/// Set style options from widget properties.
		/// </summary>
		/// <param name="styleBackground">Style for the background.</param>
		/// <param name="styleText">Style for the text.</param>
		/// <param name="style">Full style data.</param>
		public virtual void GetStyle(StyleImage styleBackground, StyleText styleText, Style style)
		{
			styleBackground.GetFrom(Background);

			if ((Owner != null) && (Owner.StyleTable))
			{
				if (GraphicsBackground != null)
				{
					GraphicsBackground.ForEach(style.Table.Background.GetFrom);
				}
			}

			if (GraphicsForeground != null)
			{
				foreach (var gf in GraphicsForeground)
				{
					if (gf != null)
					{
						styleText.GetFrom(gf.gameObject);
					}
				}
			}
		}

		/// <inheritdoc/>
		public virtual bool GetStyle(Style style)
		{
			GetStyle(style.Collections.DefaultItemBackground, style.Collections.DefaultItemText, style);

			return true;
		}
		#endregion
	}
}