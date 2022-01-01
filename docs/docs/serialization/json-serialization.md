---
sidebar_position: 5
---

# JSON Serialization

JSON support is currently provided by [MessagePack for C#](https://github.com/neuecc/MessagePack-CSharp) and while
MessagePack *technically* supports it, it's far from ideal. I highly recommend you only use JSON for debugging
purposes. Hopefully, some time in the future, I can provide a better JSON solution.

:::caution

As of right now, JSON support should be considered experimental!

:::

## Reasons to avoid JSON

#### Some data can not be deserialized
Sometimes data that has been serialized with JSON can not be deserialized. I can not say exactly what data can and can
not be converted back and forth. Just use JSON saving at your own discretion! 

#### It's not very readable anyways
JSON is meant to be human readable, and while this JSON is readable, it can be very hard to understand. Due to the JSON
serializer having to share the same space as the binary one, a lot of "fluff data" (like node names) are completely
skipped, and some strings are even hashed to numbers in order to take up a lot less space in binary.

<details><summary>JSON comparison</summary>
<p>
Here is a good looking example of what ALE should ideally generate.

```json
{
    "SaveVersion": 1,
    "Name": "JSON Example",
    "Objects": [
        {
            "Name": "Cube",
            "Active": true,
            "ID": "cube",
            "InstanceID": 1,
            "Components": [
                {
                    "Type": "UnityEngine.Transform",
                    "Properties": [
                        {
                            "ID": 0,
                            "Value": {
                                "x": 5,
                                "y": 4,
                                "z": 3
                            }
                        },
                        {
                            "ID": 1,
                            "Value": {
                                "x": 0,
                                "y": 0,
                                "z": 0
                            }
                        },
                        {
                            "ID": 2,
                            "Value": {
                                "x": 0,
                                "y": 0,
                                "z": 0
                            }
                        },                        
                        {
                            "ID": 1,
                            "Value": null
                        }
                    ]
                }
            ]
        }
    ],
    "CustomData": {
        "time": {
            "Type": "Hertzole.ALE.Example.SaveData",
            "Properties": [
                {
                    "message": "Hello! This level was saved with the number {0}!"
                },
                {
                    "number": -269548
                }
            ]
        }
    }
}
```

Very readable and clean. A bit wordy sure, but readable. Perfect for debugging purposes!

But here's what it actually generates...
```json
[
    1,
    "JSON Example",
    [
        [
            "Cube",
            true,
            24305868,
            1,
            [
                [
                    505582686,
                    [
                        0,
                        [
                            5,
                            4,
                            3
                        ],
                        1,
                        [
                            0,
                            0,
                            0
                        ],
                        2,
                        [
                            1,
                            1,
                            1
                        ],
                        3,
                        null
                    ]
                ]
            ]
        ]
    ],
    {
        "time": [
            371764105,
            [
                -1910110192,
                "Hello! This level was saved with the number {0}!",
                -2096615904,
                -269548
            ]
        ]
    }
]
```
</p>

</details>