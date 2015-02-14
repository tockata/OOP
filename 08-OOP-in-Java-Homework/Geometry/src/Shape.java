import java.util.ArrayList;

public abstract class Shape {
    private ArrayList<Vertex> vertices = new ArrayList<Vertex>();

    public Shape(ArrayList<Vertex> vertices) {
        this.setVertices(vertices);
    }

    public ArrayList<Vertex> getVertices() {
        return vertices;
    }

    public void setVertices(ArrayList<Vertex> vertices) {
        this.vertices = vertices;
    }

    @Override
    public String toString() {
        String shape = "Vertices:\n";
        for (int i = 0; i < this.vertices.size(); i++) {
             shape += (i + 1) +
                     ": X: " + this.vertices.get(i).getX() +
                     ", Y: " + this.vertices.get(i).getY() +
                     (Double.isNaN(this.vertices.get(i).getZ()) ? "\n" :
                     ", Z: " + this.vertices.get(i).getZ() + "\n");
        }
        return shape;
    }
}
