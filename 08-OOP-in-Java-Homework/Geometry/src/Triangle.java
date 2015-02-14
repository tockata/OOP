import java.util.ArrayList;

public class Triangle extends PlaneShape {
    private ArrayList<Vertex> vertices2D = new ArrayList<Vertex>();

    public Triangle(ArrayList<Vertex> vertices2D) {
        super(vertices2D);
        this.setTriangle(vertices2D);
    }

    public void setTriangle(ArrayList<Vertex> vertices2D) {
        if (vertices2D.size() != 3) {
            throw new IllegalArgumentException("Triangle must have 3 vertices!");
        }

        this.vertices2D = vertices2D;
    }

    @Override
    public double getArea() {
        double[] sides = getTriangleSides(this.vertices2D);
        double halfPerimeter = this.getPerimeter() / 2;
        double area = Math.sqrt(
                halfPerimeter *
                (halfPerimeter - sides[0]) *
                (halfPerimeter - sides[1]) *
                (halfPerimeter - sides[2])
        );
        return area;
    }

    @Override
    public double getPerimeter() {
        double[] sides = getTriangleSides(this.vertices2D);
        return sides[0] + sides[1] + sides[2];
    }

    private double[] getTriangleSides(ArrayList<Vertex> vertices2D){
        double[] sides = new double[3];
        sides[0] = this.calculateDistanceBetweenTwoVertices(vertices2D.get(0), vertices2D.get(1));
        sides[1] = this.calculateDistanceBetweenTwoVertices(vertices2D.get(0), vertices2D.get(2));
        sides[2] = this.calculateDistanceBetweenTwoVertices(vertices2D.get(1), vertices2D.get(2));

        return sides;
    }
}
