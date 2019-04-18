// Graph.cpp : Этот файл содержит функцию "main". Здесь начинается и заканчивается выполнение программы.
//

#include "pch.h"
#include <iostream>
#include <stack>
#include <string>
using namespace std;
class Vertex
{
public:
	bool hit = false;
	int index = -1;
};
class Graph
{
public: 
	int cntOfVertexes = 0;
	int **m_adjacency;
	char **colors;
	Vertex *vertexes[5];
	Graph()
	{
		for (int i = 0; i < 5; i++)
		{
			vertexes[i] = new Vertex();
		}
		m_adjacency = new int*[5];
		colors = new char*[5];
		for (int i = 0; i < 5; i++)
		{
			m_adjacency[i] = new int[5];
			colors[i] = new char[5];
		}
		for (int i = 0; i < 5; i++)
		{
			for (int j = 0; j < 5; j++)
			{
				m_adjacency[i][j] = 0;
				colors[i][j] = 'g';
			}	
		}

	}
	
	void AddVertex(Vertex* vertex)
	{
		if (cntOfVertexes < 5)
		{
			vertex->index = cntOfVertexes;
			vertexes[cntOfVertexes] = vertex;
			cntOfVertexes++;
		}
	}
	void AddWay(Vertex* first, Vertex* second)
	{
		int i1 = first->index;
		int i2 = second->index;
		m_adjacency[i1][i2] = 1;
		m_adjacency[i2][i1] = 1;
	}
	int DF_search(Vertex* first, Vertex* second)
	{
		int i, j, lastindex = -1;
		int cnt = 0;
		bool checkgreen = false;
		char lastcolor = 'g';
		stack<Vertex> stack;
		stack.push(*first);
		while (stack.size() > 0)
		{
			cout << stack.top().index << endl;
			checkgreen = false;
			if (stack.top().index == second->index)
				return cnt;
			i = stack.top().index;
			if (lastcolor == 'g' && !vertexes[i]->hit)
			{
				if (lastindex != -1)
				{
					colors[lastindex][i] = 'y';
					colors[i][lastindex] = 'y';
				}
				vertexes[i]->hit = true;
				for (j = 0; j < 5; j++)
				{
					if (m_adjacency[i][j] == 1)
					{
						if (colors[i][j] == 'g')
						{
							lastcolor = 'g';
							cnt++;
							stack.push(*vertexes[j]);
							checkgreen = true;
							break;
						}
					}
				}
				if (!checkgreen)
				{
					cnt++;
					stack.pop();
					if (stack.size() > 0)
					{
						colors[i][stack.top().index] = 'r';
						colors[stack.top().index][i] = 'r';
					}
					lastcolor = 'r';
				}
				lastindex = i;

				continue;
			}
			if (lastcolor == 'g' && vertexes[i]->hit)
			{
				colors[i][lastindex] = 'y';
				colors[lastindex][i] = 'y';
				lastcolor = 'y';
				lastindex = i;
				cnt++;
				stack.pop();
				continue;
			}
			if (lastcolor == 'y' && vertexes[i]->hit)
			{
				for (j = 0; j < 5; j++)
				{
					if (m_adjacency[i][j] == 1)
					{
						if (colors[i][j] == 'g')
						{
							lastcolor = 'g';
							cnt++;
							stack.push(*vertexes[j]);
							checkgreen = true;
							colors[lastindex][i] = 'r';
							colors[i][lastindex] = 'r';
							break;
						}
					}
				}
				if (!checkgreen)
				{
					cnt++;
					stack.pop();
					if (stack.size() > 0)
					{
						colors[i][stack.top().index] = 'r';
						colors[stack.top().index][i] = 'r';
						lastcolor = 'r';
					}
				}
				lastindex = i;
				continue;
			}

		}
		HitOff();
		return -1;
	}
	void HitOff()
	{
		for (int i = 0; i < 5; i++)
		{
			vertexes[i]->hit = false;
		}
		for (int i = 0; i < 5; i++)
		{
			for (int j = 0; j < 5; j++)
			{
				colors[i][j] = 'g';
			}

		}
	}
};
int main()
{
	Graph g;
	Vertex* a = new Vertex();
	Vertex* b = new Vertex();
	Vertex* c = new Vertex();
	Vertex* d = new Vertex();
	Vertex* e = new Vertex();
	g.AddVertex(a);
	g.AddVertex(b);
	g.AddVertex(c);
	g.AddVertex(d);
	g.AddVertex(e);
	g.AddWay(a, b);
	g.AddWay(b, d);
	g.AddWay(b, c);
	g.AddWay(a, d);
	g.AddWay(c, d);
	g.AddWay(d, e);
	int cnt = g.DF_search(a, e);
	cout << "LengthOFWay is " << cnt << endl;
	return 0;
}

// Запуск программы: CTRL+F5 или меню "Отладка" > "Запуск без отладки"
// Отладка программы: F5 или меню "Отладка" > "Запустить отладку"

// Советы по началу работы 
//   1. В окне обозревателя решений можно добавлять файлы и управлять ими.
//   2. В окне Team Explorer можно подключиться к системе управления версиями.
//   3. В окне "Выходные данные" можно просматривать выходные данные сборки и другие сообщения.
//   4. В окне "Список ошибок" можно просматривать ошибки.
//   5. Последовательно выберите пункты меню "Проект" > "Добавить новый элемент", чтобы создать файлы кода, или "Проект" > "Добавить существующий элемент", чтобы добавить в проект существующие файлы кода.
//   6. Чтобы снова открыть этот проект позже, выберите пункты меню "Файл" > "Открыть" > "Проект" и выберите SLN-файл.
