### Features

- Character Selection: Uses different Prefabs (and its variants) with different starting Health amount
- Simple Character Movement
- Feel: Jump, Spawn, Death Effects are handled by Asset "Feel"
- Health System: Character Preview Image, Health Icons are updated when character receives damages.
- Damage System: Pole has Damage attribute. Currently set to 1 and can be changed from the inspector. It was going to have multiple values for different stages but only 1 stage was implemented in this version.

### Assets:

- Feel

https://assetstore.unity.com/packages/tools/particles-effects/feel-183370

> Packed with more than 130 feedbacks, it'll let you easily trigger screenshakes, haptics, animate transforms, play with sounds, cameras, particles, physics, post processing, text, shaders, time, UI, and add juice to every aspect of your game.

This asset is used to handle ReceiveDamageEvent, ReceiveHealEvent, etc.
