import interfaces.AreaMeasurable;
import interfaces.VolumeMeasurable;

import java.util.ArrayList;

public abstract class SpaceShape extends Shape
        implements AreaMeasurable, VolumeMeasurable {
    public SpaceShape(ArrayList<Vertex> vertices) {
        super(vertices);
        this.setVertices3D(vertices);
    }

    public void setVertices3D(ArrayList<Vertex> vertices3D) {
        for (Vertex vertex : vertices3D) {
            if (Double.isNaN(vertex.getZ())) {
                throw new IllegalArgumentException("This list of vertices contains 2D vetrices!");
            }
        }
    }

    @Override
    public String toString() {
        String spaceShape = "Shape type: " +
                this.getClass().getName() + "\n" + super.toString();

        spaceShape += "Area: " + String.format("%.2f", this.getArea()) + "\n";
        spaceShape += "Volume: " + String.format("%.2f", this.getVolume());
        return spaceShape;
    }
}
