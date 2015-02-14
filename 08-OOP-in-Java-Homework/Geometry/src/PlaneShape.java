import interfaces.AreaMeasurable;
import interfaces.PerimeterMeasurable;

import java.util.ArrayList;

public abstract class PlaneShape extends Shape
        implements PerimeterMeasurable, AreaMeasurable {
    public PlaneShape(ArrayList<Vertex> vertices2D) {
        super(vertices2D);
        this.setVertices2D(vertices2D);
    }

    public void setVertices2D(ArrayList<Vertex> vertices2D) {
        for (Vertex vertex : vertices2D) {
            if (!Double.isNaN(vertex.getZ())) {
                throw new IllegalArgumentException("This list of vertices contains 3D vetrices!");
            }
        }
    }

    public double calculateDistanceBetweenTwoVertices(Vertex v1, Vertex v2){
        double distance = Math.sqrt(
                (Math.pow((v1.getX() - v2.getX()), 2) +
                Math.pow((v1.getY() - v2.getY()), 2)));

        return distance;
    }

    @Override
    public String toString() {
        String planeShape = "Shape type: " +
                this.getClass().getName() + "\n" + super.toString();

        planeShape += "Perimeter: " + String.format("%.2f", this.getPerimeter()) + "\n";
        planeShape += "Area: " + String.format("%.2f", this.getArea());
        return planeShape;
    }
}
