# Modular Movement Framework
![MovementImage](https://dhjhkxawhe8q4.cloudfront.net/mit-press/wp-content/uploads/2023/01/19124426/explore_movement_blog_teaser_1050x700-1.jpg)


An extensible, modular movement framework for Unity game development, designed to make prototyping and iteration fast without sacrificing long-term scalability.

Movement behavior is composed from small, self-contained Movement Modules that each handle a single responsibility (walking, acceleration, slowing, overrides, etc.). Modules are evaluated in a prioritized order by a central CharacterMotor, allowing complex movement behavior to emerge through composition rather than inheritance.

This architecture decouples input, movement intent, and velocity shaping, making it easy to:

- Add or remove movement features at runtime

- Swap implementations without rewriting core logic

- Prototype new mechanics safely and quickly

- Extend behavior through new modules instead of modifying existing code

The framework is engine-friendly, inspector-driven, and built with extensibility in mind, making it suitable for both rapid prototyping and production-scale projects.