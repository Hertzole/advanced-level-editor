"use strict";(self.webpackChunkale_docs=self.webpackChunkale_docs||[]).push([[908],{3905:function(e,t,r){r.d(t,{Zo:function(){return c},kt:function(){return m}});var n=r(7294);function a(e,t,r){return t in e?Object.defineProperty(e,t,{value:r,enumerable:!0,configurable:!0,writable:!0}):e[t]=r,e}function i(e,t){var r=Object.keys(e);if(Object.getOwnPropertySymbols){var n=Object.getOwnPropertySymbols(e);t&&(n=n.filter((function(t){return Object.getOwnPropertyDescriptor(e,t).enumerable}))),r.push.apply(r,n)}return r}function o(e){for(var t=1;t<arguments.length;t++){var r=null!=arguments[t]?arguments[t]:{};t%2?i(Object(r),!0).forEach((function(t){a(e,t,r[t])})):Object.getOwnPropertyDescriptors?Object.defineProperties(e,Object.getOwnPropertyDescriptors(r)):i(Object(r)).forEach((function(t){Object.defineProperty(e,t,Object.getOwnPropertyDescriptor(r,t))}))}return e}function s(e,t){if(null==e)return{};var r,n,a=function(e,t){if(null==e)return{};var r,n,a={},i=Object.keys(e);for(n=0;n<i.length;n++)r=i[n],t.indexOf(r)>=0||(a[r]=e[r]);return a}(e,t);if(Object.getOwnPropertySymbols){var i=Object.getOwnPropertySymbols(e);for(n=0;n<i.length;n++)r=i[n],t.indexOf(r)>=0||Object.prototype.propertyIsEnumerable.call(e,r)&&(a[r]=e[r])}return a}var l=n.createContext({}),p=function(e){var t=n.useContext(l),r=t;return e&&(r="function"==typeof e?e(t):o(o({},t),e)),r},c=function(e){var t=p(e.components);return n.createElement(l.Provider,{value:t},e.children)},u={inlineCode:"code",wrapper:function(e){var t=e.children;return n.createElement(n.Fragment,{},t)}},d=n.forwardRef((function(e,t){var r=e.components,a=e.mdxType,i=e.originalType,l=e.parentName,c=s(e,["components","mdxType","originalType","parentName"]),d=p(r),m=a,f=d["".concat(l,".").concat(m)]||d[m]||u[m]||i;return r?n.createElement(f,o(o({ref:t},c),{},{components:r})):n.createElement(f,o({ref:t},c))}));function m(e,t){var r=arguments,a=t&&t.mdxType;if("string"==typeof e||a){var i=r.length,o=new Array(i);o[0]=d;var s={};for(var l in t)hasOwnProperty.call(t,l)&&(s[l]=t[l]);s.originalType=e,s.mdxType="string"==typeof e?e:a,o[1]=s;for(var p=2;p<i;p++)o[p]=r[p];return n.createElement.apply(null,o)}return n.createElement.apply(null,r)}d.displayName="MDXCreateElement"},7810:function(e,t,r){r.r(t),r.d(t,{frontMatter:function(){return s},contentTitle:function(){return l},metadata:function(){return p},toc:function(){return c},default:function(){return d}});var n=r(7462),a=r(3366),i=(r(7294),r(3905)),o=["components"],s={sidebar_position:1},l="About Serialization",p={unversionedId:"serialization/about-serialization",id:"serialization/about-serialization",title:"About Serialization",description:"ALE will attempt to serialize all your exposed components and custom fields.",source:"@site/docs/serialization/about-serialization.md",sourceDirName:"serialization",slug:"/serialization/about-serialization",permalink:"/advanced-level-editor/docs/serialization/about-serialization",editUrl:"https://github.com/hertzole/advanced-level-editor/tree/master/docs/docs/serialization/about-serialization.md",tags:[],version:"current",sidebarPosition:1,frontMatter:{sidebar_position:1},sidebar:"tutorialSidebar",previous:{title:"Custom Play Mode",permalink:"/advanced-level-editor/docs/playmode/custom-playmode"},next:{title:"C# Primitives",permalink:"/advanced-level-editor/docs/serialization/c-primitives"}},c=[{value:"Exposed Components",id:"exposed-components",children:[],level:2},{value:"Custom Data",id:"custom-data",children:[],level:2},{value:"Serialization Rules",id:"serialization-rules",children:[{value:"When serializing exposed components:",id:"when-serializing-exposed-components",children:[],level:4},{value:"When serializing custom types:",id:"when-serializing-custom-types",children:[],level:4}],level:2},{value:"Custom Formatters",id:"custom-formatters",children:[],level:2}],u={toc:c};function d(e){var t=e.components,r=(0,a.Z)(e,o);return(0,i.kt)("wrapper",(0,n.Z)({},u,r,{components:t,mdxType:"MDXLayout"}),(0,i.kt)("h1",{id:"about-serialization"},"About Serialization"),(0,i.kt)("p",null,"ALE will attempt to serialize all your exposed components and custom fields.\nThe serialization backend is provided by ",(0,i.kt)("a",{parentName:"p",href:"https://github.com/neuecc/MessagePack-CSharp"},"MessagePack for C#"),"\nto enable fast and performant serialization both to Binary and JSON."),(0,i.kt)("h2",{id:"exposed-components"},"Exposed Components"),(0,i.kt)("p",null,"ALE will serialize all components that have been exposed to the level editor.\n(See ",(0,i.kt)("a",{parentName:"p",href:"/docs/attributes/exposetoleveleditor"},"Expose To Level Editor attribute"),") It can serialize all the standard\n",(0,i.kt)("a",{parentName:"p",href:"/docs/serialization/c-primitives"},"C# primitives"),", ",(0,i.kt)("a",{parentName:"p",href:"/docs/serialization/unity-primitives"},"Unity primitives"),", and some\n",(0,i.kt)("a",{parentName:"p",href:"/docs/serialization/custom-types"},"custom types"),"."),(0,i.kt)("details",null,(0,i.kt)("summary",null,"Generated Code"),(0,i.kt)("p",null,(0,i.kt)("p",null,"This is the code that it will generate a wrapper and formatter from."),(0,i.kt)("pre",null,(0,i.kt)("code",{parentName:"pre",className:"language-cs"},"using UnityEngine;\nusing Hertzole.ALE;\n\npublic class ExposedClass : MonoBehaviour\n{\n    [ExposeToLevelEditor(0)]\n    public int intValue;\n    [ExposeToLevelEditor(1)]\n    public string stringValue;\n}\n")),(0,i.kt)("p",null,"First it creates a wrapper inside ExposeClass."),(0,i.kt)("pre",null,(0,i.kt)("code",{parentName:"pre",className:"language-cs"},"using System.Collections.Generic;\nusing System.Runtime.CompilerServices;\nusing Hertzole.ALE;\nusing MessagePack;\n\npublic struct ALE__GENERATED__ExposedClassComponentWrapper : IExposedWrapper\n{\n    public Dictionary<int, object> Values { get; set; }\n    public Dictionary<int, bool> Dirty { get; set; }\n\n    public void Serialize(int id, ref MessagePackWriter writer, MessagePackSerializerOptions options)\n    {\n        switch (id)\n        {\n            case 0:\n                writer.WriteInt32((int)Values[0]);\n                break;\n            case 1:\n                options.Resolver.GetFormatterWithVerify<string>().Serialize(ref writer, (string)Values[1], options);\n                break;\n        }\n    }\n\n    public object Deserialize(int id, ref MessagePackReader reader, MessagePackSerializerOptions options)\n    {\n        switch (id)\n        {\n            case 0:\n                return reader.ReadInt32();\n            case 1:\n                return reader.ReadString();\n            default:\n                return null;\n        }\n    }\n}\n")),(0,i.kt)("p",null,"Then lastly it creates the formatter."),(0,i.kt)("pre",null,(0,i.kt)("code",{parentName:"pre",className:"language-cs"},"using System;\nusing System.Collections.Generic;\nusing MessagePack;\nusing MessagePack.Formatters;\n\npublic class ExposedClass_Formatter : IMessagePackFormatter<ExposedClass.ALE__GENERATED__ExposedClassComponentWrapper>, IMessagePackFormatter\n{\n    public void Serialize(ref MessagePackWriter writer, ExposedClass.ALE__GENERATED__ExposedClassComponentWrapper wrapper, MessagePackSerializerOptions options)\n    {\n        writer.WriteArrayHeader(4);\n        writer.WriteInt32(0);\n        wrapper.Serialize(0, ref writer, options);\n        writer.WriteInt32(1);\n        wrapper.Serialize(1, ref writer, options);\n    }\n\n    public ExposedClass.ALE__GENERATED__ExposedClassComponentWrapper Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)\n    {\n        if (reader.TryReadNil())\n        {\n            throw new InvalidOperationException();\n        }\n        options.Security.DepthStep(ref reader);\n        int num = reader.ReadArrayHeader();\n        ExposedClass.ALE__GENERATED__ExposedClassComponentWrapper wrapper = default(ExposedClass.ALE__GENERATED__ExposedClassComponentWrapper);\n        wrapper.Values = new Dictionary<int, object>(2);\n        wrapper.Dirty = new Dictionary<int, bool>(2);\n        for (int i = 0; i < num / 2; i++)\n        {\n            switch (reader.ReadInt32())\n            {\n                case 0:\n                    wrapper.Values[0] = wrapper.Deserialize(0, ref reader, options);\n                    wrapper.Dirty[0] = true;\n                    break;\n                case 1:\n                    wrapper.Values[1] = wrapper.Deserialize(1, ref reader, options);\n                    wrapper.Dirty[1] = true;\n                    break;\n            }\n        }\n        reader.Depth--;\n        return wrapper;\n    }\n}\n")))),(0,i.kt)("h2",{id:"custom-data"},"Custom Data"),(0,i.kt)("p",null,"Custom data is, as the name implies, custom data being saved with the level data when saving.\nYou can save the standard ",(0,i.kt)("a",{parentName:"p",href:"/docs/serialization/c-primitives"},"C# primitives"),", ",(0,i.kt)("a",{parentName:"p",href:"/docs/serialization/unity-primitives"},"Unity primitives"),",\nand some ",(0,i.kt)("a",{parentName:"p",href:"/docs/serialization/custom-types"},"custom types")," in custom data and retrieve it later when loading a level.\nSee ",(0,i.kt)("a",{parentName:"p",href:"/docs/components/save-manager"},"save manager")," for more info about actually using custom data. "),(0,i.kt)("h2",{id:"serialization-rules"},"Serialization Rules"),(0,i.kt)("p",null,"There are some rules that the weaver follows to create formatters for your exposed components and custom types.\nThey can be really helpful in order to get the most reliable output from your data."),(0,i.kt)("h4",{id:"when-serializing-exposed-components"},"When serializing exposed components:"),(0,i.kt)("ul",null,(0,i.kt)("li",{parentName:"ul"},"Unity object/component references ",(0,i.kt)("em",{parentName:"li"},"ARE")," allowed"),(0,i.kt)("li",{parentName:"ul"},"Only specified fields and properties are serialized"),(0,i.kt)("li",{parentName:"ul"},"Exposed properties are mapped to their ID"),(0,i.kt)("li",{parentName:"ul"},"Private, protected, and public fields/properties can be serialized")),(0,i.kt)("h4",{id:"when-serializing-custom-types"},"When serializing custom types:"),(0,i.kt)("ul",null,(0,i.kt)("li",{parentName:"ul"},"Unity object/component references ",(0,i.kt)("em",{parentName:"li"},"ARE NOT")," allowed"),(0,i.kt)("li",{parentName:"ul"},"Only structs can be serialized"),(0,i.kt)("li",{parentName:"ul"},"Only fields are serialized"),(0,i.kt)("li",{parentName:"ul"},"All fields are serialized"),(0,i.kt)("li",{parentName:"ul"},"Fields can be ignored with the ",(0,i.kt)("inlineCode",{parentName:"li"},"NonSerializable")," attribute"),(0,i.kt)("li",{parentName:"ul"},"Fields are mapped to their names"),(0,i.kt)("li",{parentName:"ul"},"Only public fields are serialized")),(0,i.kt)("h2",{id:"custom-formatters"},"Custom Formatters"),(0,i.kt)("p",null,"\u26a0 ",(0,i.kt)("strong",{parentName:"p"},"Custom formatters are not yet supported.")," \u26a0"),(0,i.kt)("p",null,"Custom formatters give you the ability to easily create your own formatter that will be hooked into the level editor\nso you can customize the serialization behavior of your custom types."))}d.isMDXComponent=!0}}]);