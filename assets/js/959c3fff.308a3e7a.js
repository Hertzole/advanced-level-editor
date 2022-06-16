"use strict";(self.webpackChunkale_docs=self.webpackChunkale_docs||[]).push([[21],{3905:function(e,t,r){r.d(t,{Zo:function(){return u},kt:function(){return m}});var o=r(7294);function n(e,t,r){return t in e?Object.defineProperty(e,t,{value:r,enumerable:!0,configurable:!0,writable:!0}):e[t]=r,e}function i(e,t){var r=Object.keys(e);if(Object.getOwnPropertySymbols){var o=Object.getOwnPropertySymbols(e);t&&(o=o.filter((function(t){return Object.getOwnPropertyDescriptor(e,t).enumerable}))),r.push.apply(r,o)}return r}function l(e){for(var t=1;t<arguments.length;t++){var r=null!=arguments[t]?arguments[t]:{};t%2?i(Object(r),!0).forEach((function(t){n(e,t,r[t])})):Object.getOwnPropertyDescriptors?Object.defineProperties(e,Object.getOwnPropertyDescriptors(r)):i(Object(r)).forEach((function(t){Object.defineProperty(e,t,Object.getOwnPropertyDescriptor(r,t))}))}return e}function a(e,t){if(null==e)return{};var r,o,n=function(e,t){if(null==e)return{};var r,o,n={},i=Object.keys(e);for(o=0;o<i.length;o++)r=i[o],t.indexOf(r)>=0||(n[r]=e[r]);return n}(e,t);if(Object.getOwnPropertySymbols){var i=Object.getOwnPropertySymbols(e);for(o=0;o<i.length;o++)r=i[o],t.indexOf(r)>=0||Object.prototype.propertyIsEnumerable.call(e,r)&&(n[r]=e[r])}return n}var s=o.createContext({}),p=function(e){var t=o.useContext(s),r=t;return e&&(r="function"==typeof e?e(t):l(l({},t),e)),r},u=function(e){var t=p(e.components);return o.createElement(s.Provider,{value:t},e.children)},c={inlineCode:"code",wrapper:function(e){var t=e.children;return o.createElement(o.Fragment,{},t)}},d=o.forwardRef((function(e,t){var r=e.components,n=e.mdxType,i=e.originalType,s=e.parentName,u=a(e,["components","mdxType","originalType","parentName"]),d=p(r),m=n,f=d["".concat(s,".").concat(m)]||d[m]||c[m]||i;return r?o.createElement(f,l(l({ref:t},u),{},{components:r})):o.createElement(f,l({ref:t},u))}));function m(e,t){var r=arguments,n=t&&t.mdxType;if("string"==typeof e||n){var i=r.length,l=new Array(i);l[0]=d;var a={};for(var s in t)hasOwnProperty.call(t,s)&&(a[s]=t[s]);a.originalType=e,a.mdxType="string"==typeof e?e:n,l[1]=a;for(var p=2;p<i;p++)l[p]=r[p];return o.createElement.apply(null,l)}return o.createElement.apply(null,r)}d.displayName="MDXCreateElement"},7629:function(e,t,r){r.r(t),r.d(t,{frontMatter:function(){return a},contentTitle:function(){return s},metadata:function(){return p},toc:function(){return u},default:function(){return d}});var o=r(7462),n=r(3366),i=(r(7294),r(3905)),l=["components"],a={},s="Expose To Level Editor",p={unversionedId:"attributes/exposetoleveleditor",id:"attributes/exposetoleveleditor",title:"Expose To Level Editor",description:"ExposeToLevelEditor is one of the most important attributes in all of ALE. This attribute exposes your fields/properties",source:"@site/docs/attributes/exposetoleveleditor.md",sourceDirName:"attributes",slug:"/attributes/exposetoleveleditor",permalink:"/advanced-level-editor/docs/attributes/exposetoleveleditor",editUrl:"https://github.com/hertzole/advanced-level-editor/tree/master/docs/docs/attributes/exposetoleveleditor.md",tags:[],version:"current",frontMatter:{},sidebar:"tutorialSidebar",previous:{title:"Create A Mode",permalink:"/advanced-level-editor/docs/editor-modes/create-mode"},next:{title:"Formerly Hashed As",permalink:"/advanced-level-editor/docs/attributes/formerlyhashedas"}},u=[{value:"Properties",id:"properties",children:[],level:2},{value:"Usage",id:"usage",children:[],level:2}],c={toc:u};function d(e){var t=e.components,r=(0,n.Z)(e,l);return(0,i.kt)("wrapper",(0,o.Z)({},c,r,{components:t,mdxType:"MDXLayout"}),(0,i.kt)("h1",{id:"expose-to-level-editor"},"Expose To Level Editor"),(0,i.kt)("p",null,(0,i.kt)("inlineCode",{parentName:"p"},"ExposeToLevelEditor")," is one of the most important attributes in all of ALE. This attribute exposes your fields/properties\nto the level editor so that they can be efficiently changed and serialized at runtime."),(0,i.kt)("p",null,"When assigning the attribute onto your target field/property, you must assign an ID. ",(0,i.kt)("strong",{parentName:"p"},"The ID must be unique!")," The\nID will be used by the serialization system to map your fields/properties. Changing/removing an ID can cause a loss\nof data when deserializing."),(0,i.kt)("p",null,"Exposed fields/properties are gathered in a specific order. First it collects all the fields in the exposed class.\nThen it collects all the properties. The order of your fields/properties in your file matter as that is the order\nthey will be collected in. The order can, however, be overwritten with the order property mentioned below."),(0,i.kt)("h2",{id:"properties"},"Properties"),(0,i.kt)("p",null,(0,i.kt)("inlineCode",{parentName:"p"},"ExposeToLevelEditor")," comes with a few extra properties you can set to modify the exposed field/property."),(0,i.kt)("ul",null,(0,i.kt)("li",{parentName:"ul"},(0,i.kt)("inlineCode",{parentName:"li"},"customName")," Allows you to set a name that should be shown in the runtime inspector."),(0,i.kt)("li",{parentName:"ul"},(0,i.kt)("inlineCode",{parentName:"li"},"visible")," Allows you to hide the field/property from the runtime inspector. This does not stop it from being serialized. "),(0,i.kt)("li",{parentName:"ul"},(0,i.kt)("inlineCode",{parentName:"li"},"order")," Sets the order in the runtime inspector. Higher means lower down.")),(0,i.kt)("h2",{id:"usage"},"Usage"),(0,i.kt)("pre",null,(0,i.kt)("code",{parentName:"pre",className:"language-cs"},"using UnityEngine;\nusing Hertzole.ALE;\n\npublic class ExposedClass : MonoBehaviour\n{\n    [ExposeToLevelEditor(0)]\n    public int intValue;\n    [ExposeToLevelEditor(1, customName = \"Text\")] // Will show name as 'Text'\n    private string stringValue;\n    [ExposeToLevelEditor(2, visible = false)] // Will not show up in runtime inspector\n    public float FloatValue { get; set; }\n    [ExposeToLevelEditor(3, order = -10)] // Will be first in the runtime inspector\n    public byte ByteValue { get; set; }\n}\n")))}d.isMDXComponent=!0}}]);