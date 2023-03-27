using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

namespace Dracau {
    public static class VisualElementExt {
        /// <summary>
        /// Create a IMGUIContainer and add the specific options to it
        /// </summary>
        /// <param name="action"></param>
        /// <param name="flexGrow"></param>
        /// <returns></returns>
        public static IMGUIContainer CreateIMGUIContainer(this Action action, string containerName, params VisualElementOption[] options) {
            IMGUIContainer container = new IMGUIContainer();
            container.name = containerName;
            container.onGUIHandler += action.Invoke;
            container.CheckVisualElementOptions(options);
            return container;
        }

        #region VisualElement Options
        public static VisualElementOption FlexGrow(StyleFloat flexGrow) => new (VisualElementOption.Type.Flexgow, flexGrow);
        public static VisualElementOption Padding(StyleLength padding) => new (VisualElementOption.Type.Padding, padding);
        public static VisualElementOption Margin(StyleLength margin) => new (VisualElementOption.Type.Margin, margin);
        public static VisualElementOption BorderWidth(StyleFloat borderWidth) => new (VisualElementOption.Type.BorderWidth, borderWidth);
        public static VisualElementOption BorderColor(StyleColor borderColor) => new (VisualElementOption.Type.BorderColor, borderColor);
        public static VisualElementOption JustifyContent(StyleEnum<Justify> justify) => new (VisualElementOption.Type.JustifyContent, justify);
        public static VisualElementOption DisplayStyle(StyleEnum<DisplayStyle> display) => new (VisualElementOption.Type.DisplayStyle, display);
        public static VisualElementOption FontSize(StyleLength fontSize) => new (VisualElementOption.Type.FontSize, fontSize);
        public static VisualElementOption FontStyle(StyleEnum<FontStyle> fontStyle) => new (VisualElementOption.Type.FontStyle, fontStyle);
        public static VisualElementOption AlignText(StyleEnum<Align> align) => new (VisualElementOption.Type.Aligntext, align);
        #endregion VisualElement Options
        
        #region Set Options Value
        /// <summary>
        /// Check the options to apply to the visual element
        /// </summary>
        /// <param name="element"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        private static VisualElement CheckVisualElementOptions(this VisualElement element, VisualElementOption[] options) {
            foreach (VisualElementOption option in options) {
                switch (option.type) {
                    case VisualElementOption.Type.Flexgow:
                        element.style.flexGrow = (StyleFloat) option.value;
                        break;

                    case VisualElementOption.Type.Padding:
                        element.SetPadding((StyleLength) option.value);
                        break;

                    case VisualElementOption.Type.Margin:
                        element.SetMargin((StyleLength) option.value);
                        break;

                    case VisualElementOption.Type.BorderWidth:
                        element.SetBorderWidth((StyleFloat) option.value);
                        break;

                    case VisualElementOption.Type.BorderColor:
                        element.SetBorderColor((StyleColor) option.value);
                        break;

                    case VisualElementOption.Type.JustifyContent:
                        element.SetJustification((StyleEnum<Justify>) option.value);
                        break;

                    case VisualElementOption.Type.DisplayStyle:
                        element.style.display = (StyleEnum<DisplayStyle>) option.value;
                        break;

                    case VisualElementOption.Type.FontSize:
                        element.style.fontSize = (StyleLength) option.value;
                        break;
                    
                    case VisualElementOption.Type.FontStyle:
                        element.style.unityFontStyleAndWeight = (StyleEnum<FontStyle>) option.value;
                        break;
                    
                    case VisualElementOption.Type.Aligntext:
                        element.style.alignSelf = (StyleEnum<Align>) option.value;
                        break;
                    
                    default: throw new ArgumentOutOfRangeException();
                }
            }

            return element;
        }

        /// <summary>
        /// Set the padding of a visual element
        /// </summary>
        /// <param name="element"></param>
        /// <param name="padding"></param>
        /// <returns></returns>
        public static VisualElement SetPadding(this VisualElement element, StyleLength padding) {
            element.style.paddingTop = padding;
            element.style.paddingRight = padding;
            element.style.paddingBottom = padding;
            element.style.paddingLeft = padding;
            return element;
        }
        
        /// <summary>
        /// Set the margin of a visual element
        /// </summary>
        /// <param name="element"></param>
        /// <param name="margin"></param>
        /// <returns></returns>
        public static VisualElement SetMargin(this VisualElement element, StyleLength margin) {
            element.style.marginTop = margin;
            element.style.marginRight = margin;
            element.style.marginBottom = margin;
            element.style.marginLeft = margin;
            return element;
        }
        
        /// <summary>
        /// Set the width of the borders of a visual element
        /// </summary>
        /// <param name="element"></param>
        /// <param name="bortderWidth"></param>
        /// <returns></returns>
        public static VisualElement SetBorderWidth(this VisualElement element, StyleFloat bortderWidth) {
            element.style.borderTopWidth = bortderWidth;
            element.style.borderRightWidth = bortderWidth;
            element.style.borderBottomWidth = bortderWidth;
            element.style.borderLeftWidth = bortderWidth;
            return element;
        }
        
        /// <summary>
        /// Set the color of the borders of a visual element
        /// </summary>
        /// <param name="element"></param>
        /// <param name="borderColor"></param>
        /// <returns></returns>
        public static VisualElement SetBorderColor(this VisualElement element, StyleColor borderColor) {
            element.style.borderTopColor = borderColor;
            element.style.borderRightColor = borderColor;
            element.style.borderBottomColor = borderColor;
            element.style.borderLeftColor = borderColor;
            return element;
        }

        /// <summary>
        /// Set the justification of a visual element
        /// </summary>
        /// <param name="element"></param>
        /// <param name="justification"></param>
        /// <returns></returns>
        public static VisualElement SetJustification(this VisualElement element, StyleEnum<Justify> justification) {
            element.style.justifyContent = justification;
            return element;
        }
        #endregion Set Options Value
    }

    /// <summary>
    /// Class which allow to set some parameters to a visual element
    /// </summary>
    public sealed class VisualElementOption {
        public enum Type {
            Flexgow,
            Padding,
            Margin,
            BorderWidth,
            BorderColor,
            JustifyContent,
            Aligntext,
            DisplayStyle,
            FontSize,
            FontStyle,
            Other
        }

        public Type type;
        public object value;

        /// <summary>
        /// Constructor for a VisualElementOption
        /// </summary>
        /// <param name="type"></param>
        /// <param name="value"></param>
        public VisualElementOption(VisualElementOption.Type type, object value) {
            this.type = type;
            this.value = value;
        }
    }
}