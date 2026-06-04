## Multi-Stage Docker Builds for Java Applications

Multi-stage builds help create **optimized and secure Docker images** by separating the build environment from the runtime environment.

### **How It Works**
1️⃣ **Builder Stage** – Uses a **Java Development Kit (JDK)** to compile and package the application.
2️⃣ **Final Stage** – Uses a **lighter Java Runtime Environment (JRE)** to run the application efficiently.

### **Key Benefits**
✅ **Smaller Image Size** – Removes unnecessary build dependencies.
✅ **Improved Security** – Keeps only essential runtime components.
✅ **Better Performance** – Reduces resource usage and speeds up deployments.

### **Optimizing with `jlink`**
- Instead of using a full JRE, **`jlink`** allows you to create a **custom minimal runtime**.
- This includes **only the necessary Java modules**, reducing size and improving security.

### **Why Use Multi-Stage Builds?**
🔹 **Separates compilation, packaging, and testing from runtime**
🔹 **Removes development/debugging tools from production images**
🔹 **Enhances security and efficiency for Java applications**
