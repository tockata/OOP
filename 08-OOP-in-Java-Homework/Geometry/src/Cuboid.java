import java.util.ArrayList;

public class Cuboid extends SpaceShape {
    private double width;
    private double height;
    private double depth;

    public Cuboid(ArrayList<Vertex> vertices, double width, double height, double depth) {
        super(vertices);
        this.setWidth(width);
        this.setHeight(height);
        this.setDepth(depth);
        this.setVertex(vertices);
    }

    private void setVertex(ArrayList<Vertex> verticesList) {
        if (verticesList.size() != 1) {
            throw new IllegalArgumentException("Square Pyramid must have only one vertex!");
        }
    }

    public double getWidth() {
        return width;
    }

    public void setWidth(double width) {
        if (width <= 0) {
            throw new IllegalArgumentException("Width must be positive number!");
        }

        this.width = width;
    }

    public double getHeight() {
        return height;
    }

    public void setHeight(double height) {
        if (height <= 0) {
            throw new IllegalArgumentException("Height must be positive number!");
        }

        this.height = height;
    }

    public double getDepth() {
        return this.depth;
    }

    public void setDepth(double depth) {
        if (depth <= 0) {
            throw new IllegalArgumentException("Depth must be positive number!");
        }

        this.depth = depth;
    }

    @Override
    public double getArea() {
        return 2 * this.getWidth() * this.getHeight() +
                2 * this.getWidth() * this.getDepth() +
                2 * this.getHeight() * this.getDepth();
    }

    @Override
    public double getVolume() {
        return this.getWidth() * this.getHeight() * this.getDepth();
    }
}
